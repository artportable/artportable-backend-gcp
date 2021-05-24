using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;

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
      var pricesService = new PriceService();
        var prices = pricesService.List();

        var productService = new ProductService();
        var products = productService.List();

        var res = prices.Data
          .Where(p =>
            p != null &&
            p.Active == true &&
            p.Deleted != true &&
            p?.Recurring?.Interval != null &&
            products.Any(product => p.ProductId == product.Id && p.Active)
          )
          .Select(p => new StripePriceDTO()
          {
            Id = p.Id,
            Amount = (decimal) p.UnitAmount / 100,
            Currency = p.Currency,
            RecurringInterval = p.Recurring.Interval,
            Product = products.First(product => p.ProductId == product.Id).Name,
            ProductKey = products.First(product => p.ProductId == product.Id).Metadata?.GetValueOrDefault("productkey")
          })
          .ToList();

        return res;
    }

    public string CreateCustomer(string email, string fullName)
    {
      var customerService = new CustomerService();
      var options = new CustomerCreateOptions
      {
          Email = email,
          Name = fullName
      };
      var response = customerService.Create(options);

      _context.Subscriptions
        .Where(s => s.User.Email == email)
        .Single().CustomerId = response.Id;

      _context.SaveChanges();

      return response.Id;
    }

    public string CreateSubscription(string paymentMethodId, string customerId, string priceId, string promotionCodeId)
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
      return subscription.Id;
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

      var options = new SubscriptionUpdateOptions {
        CancelAtPeriodEnd = false,
        ProrationBehavior = "create_prorations",
        Items = items,
      };

      service.Update(subscriptionId, options);
    }

    public PromotionDTO GetPromotion(string promotionCode)
    {
      var promotionCodeService = new PromotionCodeService();
      var options = new PromotionCodeListOptions(){
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
  }
}
