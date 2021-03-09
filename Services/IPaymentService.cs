using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IPaymentService
  {
    List<StripePriceDTO> GetPrices();
    string CreateCustomer(string email, string fullName);
    string CreateSubscription(string paymentMethodId, string customerId, string priceId);
    void CancelSubscription(string subscriptionId);
  }
}
