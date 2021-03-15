using Stripe;

namespace Artportable.API.Services
{
  public interface IStripeService
  {
    void HandleEvent(Event e);
  }
}
