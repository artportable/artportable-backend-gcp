using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Stripe;

namespace Artportable.API.Services
{
  public class StripeService : IStripeService
  {
    ImmutableDictionary<string, ProductEnum> _products = new Dictionary<string, ProductEnum>()
    {
      {
        "prod_J3lQFj6oRprRtJ", ProductEnum.Portfolio
      },
      {
        "prod_J3lRKmuP9uzavp", ProductEnum.PortfolioPremium
      }
    }.ToImmutableDictionary();
    private APContext _context;

    public StripeService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
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
