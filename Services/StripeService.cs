using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Artportable.API.Options;
using Microsoft.Extensions.Options;
using Stripe;

namespace Artportable.API.Services
{
  public class StripeService : IStripeService
  {
    ImmutableDictionary<string, ProductEnum> _products;
    private APContext _context;

    public StripeService(APContext apContext, IOptions<ProductCodes> productCodes)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));

      _products = new Dictionary<string, ProductEnum>()
      {
        {
          productCodes.Value.PortfolioPremium, ProductEnum.PortfolioPremium
        },
        {
          productCodes.Value.Portfolio, ProductEnum.Portfolio
        }
      }.ToImmutableDictionary();
    }

    public void HandleEvent(Event e)
    {
      var subscription = e.Data.Object as Subscription;

      switch (e.Type)
      {
        // Set new subscription and expiration date
        case (Events.CustomerSubscriptionCreated):
        case (Events.PaymentIntentSucceeded):
        case (Events.InvoicePaid):
        case (Events.CustomerSubscriptionUpdated):
          var product = _products.FirstOrDefault(p => p.Key == subscription.Items.Data[0].Price.ProductId).Value;
          SetSubscripiton(subscription.CustomerId, product, subscription.CurrentPeriodEnd);
          break;
        // Downgrade to Bas
        case (Events.CustomerSubscriptionDeleted):
        case (Events.PaymentIntentPaymentFailed):
        case (Events.PaymentIntentRequiresAction):
        case (Events.InvoicePaymentFailed):
          SetSubscripiton(subscription.CustomerId, ProductEnum.Bas, null);
          break;
        default:
          return;
      }
    }

    private void SetSubscripiton(string customerId, ProductEnum product, DateTime? expirationDate)
    {
      var subscription = _context.Subscriptions.Where(s => s.CustomerId == customerId).Single();
      subscription.ProductId = (int) product;
      subscription.ExpirationDate = expirationDate;
      _context.SaveChanges();
    }
  }
}
