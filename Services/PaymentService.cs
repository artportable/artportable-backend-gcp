using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artportable.API.Services
{
  public class PaymentService : IPaymentService
  {
    private APContext _context;

    public PaymentService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
    }

    public List<StripePriceDTO> GetPrices()
    {
      var pricesOptions = new PriceListOptions
      {
        Active = true
      };
      pricesOptions.AddExpand("data.product");
      var pricesService = new PriceService();
      var prices = pricesService.List(pricesOptions);

      var res = prices.Data
        .Where(p =>
          p != null &&
          p.Active &&
          p.Deleted != true &&
          p?.Recurring?.Interval != null &&
          p.Product.Active &&
          p.Product.Metadata.ContainsKey("productkey")
        )
        .Select(p => new StripePriceDTO()
        {
          Id = p.Id,
          Amount = (decimal)p.UnitAmount / 100,
          Currency = p.Currency,
          RecurringInterval = p.Recurring.Interval,
          Product = p.Product.Name,
          ProductKey = p.Product.Metadata.GetValueOrDefault("productkey")
        })
        .ToList();

      return res;
    }

    public string CreateCustomer(string email, string fullName, string phoneNumber)
    {
      var subscription = _context.Subscriptions
         .Where(s => s.User.Email == email)
         .SingleOrDefault();
      if (string.IsNullOrWhiteSpace(subscription?.CustomerId))
      {
        var customerService = new CustomerService();
        var customers = customerService.List(new CustomerListOptions()
        {
          Email = email
        });
        var customer = customers.FirstOrDefault();
        if (customer == null)
        {
          var options = new CustomerCreateOptions
          {
            Email = email,
            Name = fullName,
            Phone = phoneNumber
          };
          customer = customerService.Create(options);
          if (subscription! != null)
          {
            subscription.CustomerId = customer.Id;
            _context.SaveChanges();
          }
        }
        return customer.Id;
      }
      return subscription.CustomerId;
    }

    public Subscription CreateSubscription(string paymentMethodId, string customerId, string priceId, string promotionCodeId)
    {
      // Attach payment method
      var options = new PaymentMethodAttachOptions
      {
        Customer = customerId,
      };
      var service = new PaymentMethodService();
      var paymentMethod = service.Attach(paymentMethodId, options);

      // Update customer's default invoice payment method
      var customerOptions = new CustomerUpdateOptions
      {
        InvoiceSettings = new CustomerInvoiceSettingsOptions
        {
          DefaultPaymentMethod = paymentMethod.Id,
        },
      };
      var customerService = new CustomerService();
      customerService.Update(customerId, customerOptions);

      // Create subscription
      var subscriptionOptions = new SubscriptionCreateOptions
      {
        Customer = customerId,
        PromotionCode = promotionCodeId,
        Items = new List<SubscriptionItemOptions>
        {
          new SubscriptionItemOptions
          {
            Price = priceId,
          },
        },
      };
      subscriptionOptions.AddExpand("latest_invoice.payment_intent");
      var subscriptionService = new SubscriptionService();

      Subscription subscription = subscriptionService.Create(subscriptionOptions);
      return subscription;
    }

    public Subscription UpgradeSubscription(string paymentMethodId, string customerId, string newPriceId, string promotionCodeId)
    {
        try
        {
            // Retrieve the customer's subscriptions
            var subscriptionService = new SubscriptionService();
            var subscriptions = subscriptionService.List(new SubscriptionListOptions
            {
                Customer = customerId,
                Status = "active",
            });

            // Find the relevant subscription (for example, choose the latest active subscription)
            var currentSubscription = subscriptions.FirstOrDefault();

            // Cancel the existing subscription
            if (currentSubscription != null)
        {
            var cancelOptions = new SubscriptionCancelOptions { InvoiceNow = true };
            var canceledSubscription = subscriptionService.Cancel(currentSubscription.Id, cancelOptions);

            // Verify if the cancellation was successful
            if (canceledSubscription.Status == "canceled")
            {
                Console.WriteLine($"Successfully canceled existing subscription: {canceledSubscription.Id}");
            }
            else
            {
                Console.WriteLine($"Failed to cancel existing subscription: {canceledSubscription.Id}");
                // Log the error or handle it appropriately
                // You may want to throw an exception here if you want the error to propagate up the call stack
            }
        }
        else
        {
            // Handle the case where no existing subscription is found
            Console.WriteLine("No active subscription found to upgrade.");
            // You may want to log this information or notify the user
        }

            // Create the new subscription
            var newSubscription = CreateSubscription(paymentMethodId, customerId, newPriceId, promotionCodeId);

            // Handle the case where new subscription creation fails
            if (newSubscription == null)
            {
                Console.WriteLine("Failed to create a new subscription.");
                // You may want to log this information or notify the user
                // Optionally, you could throw an exception here if you want the error to propagate up the call stack
            }

            return newSubscription;
        }
        catch (StripeException e)
        {
            // Handle the cancellation error
            Console.WriteLine($"Error upgrading subscription: {e.StripeError.Message}");
            // You may want to log the error, notify the user, or take other appropriate actions

            // Optionally, you could throw the exception again if you want the error to propagate up the call stack
            throw;
        }
    }



    public void CancelSubscription(string subscriptionId)
    {
      var service = new SubscriptionService();
      var subscription = service.Cancel(subscriptionId, null);
    }

    public void UpdateSubscription(string subscriptionId, string priceId)
    {
      var service = new SubscriptionService();

      var currentSubscription = service.Get(subscriptionId);

      var items = new List<SubscriptionItemOptions> {
        new SubscriptionItemOptions {
          Id = currentSubscription.Items.Data[0].Id,
          Price = priceId,
        },
      };

      var options = new SubscriptionUpdateOptions
      {
        CancelAtPeriodEnd = false,
        ProrationBehavior = "create_prorations",
        Items = items,
      };

      service.Update(subscriptionId, options);
    }

    public PromotionDTO GetPromotion(string promotionCode)
    {
      var promotionCodeService = new PromotionCodeService();
      var options = new PromotionCodeListOptions()
      {
        Code = promotionCode
      };
      var promotion = promotionCodeService.List(options)
        .Where(x => x.Active == true)
        .FirstOrDefault();

      if (promotion == null)
      {
        return null;
      }

      var discountInPercent = promotion.Coupon.PercentOff != null;

      return new PromotionDTO
      {
        Name = promotion.Coupon.Name,
        DiscountInPercent = discountInPercent,
        AmountOff = (discountInPercent ? promotion.Coupon.PercentOff : promotion.Coupon.AmountOff / 100) ?? 0,
        Currency = promotion.Coupon.Currency
      };
    }

    public async Task<bool> ValidatePaymentMethod(string paymentMethodId)
    {
      var paymentMethodService = new PaymentMethodService();
      try
      {
        var paymentMethod = await paymentMethodService.GetAsync(paymentMethodId);
        return true;
      }
      catch (System.Exception)
      {
        //throws exception if paymentmethod doesnt exist
        return false;
      }
    }

    public async Task<Invoice> CreateInvoice(string paymentMethodId, string customerId, List<string> products)
    {
      var paymentMethodOptions = new PaymentMethodAttachOptions
      {
        Customer = customerId,
      };
      var service = new PaymentMethodService();
      var paymentMethod = service.Attach(paymentMethodId, paymentMethodOptions);
      var invoiceItemService = new InvoiceItemService();
      foreach (var product in products)
      {
        var options = new InvoiceItemCreateOptions
        {
          Customer = customerId,
          Price = product,
        };
        var invoiceItem = await invoiceItemService.CreateAsync(options);
      }

      var invoiceService = new InvoiceService();
      var invoiceOptions = new InvoiceCreateOptions()
      {
        DefaultPaymentMethod = paymentMethodId,
        Customer = customerId,
        CollectionMethod = "charge_automatically",
        AutoAdvance = true,
      };
      var invoice = await invoiceService.CreateAsync(invoiceOptions);
      invoice = await invoiceService.FinalizeInvoiceAsync(invoice.Id,
      new InvoiceFinalizeOptions
      {
        Expand = new List<string>{
            "payment_intent"
        },
      });
      return invoice;
    }

    public async Task<bool> ValidateProducts(List<string> prices)
    {
      var priceService = new PriceService();
      var pricesObjects = await priceService.ListAsync();
      var pricesIds = pricesObjects.Select(x => x.Id);
      return prices.All(x => pricesIds.Contains(x));
    }
  }
}
