using System.Collections.Generic;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Stripe;
using Stripe.BillingPortal;

namespace Artportable.API.Services
{
  public interface IPaymentService
  {
    List<StripePriceDTO> GetPrices();
    string CreateCustomer(string email, string fullName, string phoneNumber);
    Subscription CreateSubscription(string paymentMethodId, string customerId, string priceId, string promotionCodeId);
    Task<Invoice> CreateInvoice(string paymentMethodId, string customerId, List<string> products);
    void CancelSubscription(string subscriptionId);
    void UpdateSubscription(string subscriptionId, string priceId);
    PromotionDTO GetPromotion(string promotionCode);
    Task<bool> ValidatePaymentMethod(string paymentMethodId);
    Task<bool> ValidateProducts(List<string> prices);

    Subscription UpgradeSubscription(string paymentMethodId, string customerId, string newPriceId, string promotionCodeId);
    Session CreateCustomerPortalSession(string customerId);

  }
}
