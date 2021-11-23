using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Artportable.API.Interfaces.Services;
using Artportable.API.Options;
using Microsoft.Extensions.Options;
using Stripe;

namespace Artportable.API.Services
{
  public class StripeService : IStripeService
  {
    ImmutableDictionary<string, ProductEnum> _products;
    private readonly ICrmService _crmService;
    private readonly APContext _context;

    public StripeService(APContext apContext, IOptions<ProductCodes> productCodes, ICrmService crmService)
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

      _crmService = crmService;
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
          _ = Task.Run(async () =>
                {
                  try
                  {
                    await _crmService.RegisterPurchase(
                      subscription.CustomerId,
                      product,
                      (Convert.ToDecimal(subscription.Items.Data[0].Price.UnitAmount / 100)),
                      subscription.Items.Data[0].Price.Currency.ToUpper(),
                      Enum.TryParse<PaymentIntervalEnum>(subscription.Items.Data[0].Plan.Interval, true, out var interval) ? interval : PaymentIntervalEnum.Month);
                  }
                  catch (System.Exception)
                  {

                  }
                }
              );
          SetSubscription(subscription.CustomerId, product, subscription.CurrentPeriodEnd);
          break;
        // Downgrade to Bas
        case (Events.CustomerSubscriptionDeleted):
        case (Events.PaymentIntentPaymentFailed):
        case (Events.PaymentIntentRequiresAction):
        case (Events.InvoicePaymentFailed):
          SetSubscription(subscription.CustomerId, ProductEnum.Bas, null);
          break;
        default:
          return;
      }
    }

    private void SetSubscription(string customerId, ProductEnum product, DateTime? expirationDate)
    {
      var subscription = _context.Subscriptions.Where(s => s.CustomerId == customerId).Single();
      subscription.ProductId = (int)product;
      subscription.ExpirationDate = expirationDate;
      _context.SaveChanges();
    }
  }
}
