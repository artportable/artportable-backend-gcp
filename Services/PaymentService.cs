using Artportable.API.DTOs;
using Artportable.API.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artportable.API.Services
{
  public class PaymentService : IPaymentService
  {

    public PaymentService()
    {
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
            products.Any(product => p.ProductId == product.Id)
          )
          .Select(p => new StripePriceDTO()
          {
            Id = p.Id,
            Amount = (decimal) p.UnitAmount / 100,
            Currency = p.Currency,
            RecurringInterval = p.Recurring.Interval,
            Product = products.First(product => p.ProductId == product.Id).Name
          })
          .ToList();

        return res;
    }

    public string CreateCustomer(string email, string fullName)
    {
      var customerService = new CustomerService();
      var response = customerService.Create(new CustomerCreateOptions
      {
          Email = email,
          Name = fullName
      });

      return response.Id;
    }

    public string CreateSubscription(string paymentMethodId, string customerId, string priceId)
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
  }
}
