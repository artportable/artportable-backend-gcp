using System.Collections.Generic;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Stripe;

namespace Artportable.API.Services
{
  public interface IPaymentService
  {
    List<StripePriceDTO> GetPrices();
    string CreateCustomer(string email, string fullName);
    Subscription CreateSubscription(string paymentMethodId, string customerId, string priceId, string promotionCodeId);
    Task<Invoice> CreateInvoice(string paymentMethodId, string customerId, List<string> products);
    void CancelSubscription(string subscriptionId);
    void UpdateSubscription(string subscriptionId, string priceId);
    PromotionDTO GetPromotion(string promotionCode);
  }
}
