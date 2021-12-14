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

    public string CreateCustomer(string email, string fullName)
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
            Name = fullName
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

    public async Task<Invoice> CreateInvoice(string paymentMethodId, string customerId, List<string> products)
    {
      var invoiceService = new InvoiceService();
      var invoiceOptions = new InvoiceCreateOptions()
      {
        DefaultPaymentMethod = paymentMethodId,
        Customer = customerId,
        CollectionMethod = "charge_automatically"
      };
      var invoice = await invoiceService.CreateAsync(invoiceOptions);
      foreach (var product in products)
      {
        var options = new InvoiceItemCreateOptions
        {
          Customer = customerId,
          Price = product,
          Invoice = invoice.Id
        };
        var invoiceItemService = new InvoiceItemService();
        var invoiceItem = await invoiceItemService.CreateAsync(options);
      }
      invoice = await invoiceService.FinalizeInvoiceAsync(
        invoice.Id,
          new InvoiceFinalizeOptions()
          {
            AutoAdvance = true,
            Expand = new List<string>{
            "payment_intent"
            }
          }
          );
      return invoice;
    }
  }
}
