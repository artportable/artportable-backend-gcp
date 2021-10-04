using System.Collections.Generic;
using Artportable.API.DTOs;
using Stripe;

namespace Artportable.API.Services
{
  public interface IPaymentService
  {
    List<StripePriceDTO> GetPrices();
    string CreateCustomer(string email, string fullName);
    Subscription CreateSubscription(string paymentMethodId, string customerId, string priceId, string promotionCodeId);
    void CancelSubscription(string subscriptionId);
    void UpdateSubscription(string subscriptionId, string priceId);
    PromotionDTO GetPromotion(string promotionCode);
  }
}
