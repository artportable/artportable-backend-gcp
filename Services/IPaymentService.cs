using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IPaymentService
  {
    string CreateIntent(PaymentIntentRequestDTO paymentIntentRequest);
    string CreateCustomer(string email, string fullName);
  }
}
