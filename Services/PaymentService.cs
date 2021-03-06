using Artportable.API.DTOs;
using Artportable.API.Enums;
using Stripe;
using System;

namespace Artportable.API.Services
{
  public class PaymentService : IPaymentService
  {

    public PaymentService()
    {
    }

    public string CreateIntent(PaymentIntentRequestDTO paymentIntentRequest)
    {
      var paymentIntents = new PaymentIntentService();
      
      var paymentIntentCreateOptions = new PaymentIntentCreateOptions {
        Amount = CalculateAmount(paymentIntentRequest),
        Currency = "sek",
      };

      var paymentIntent = paymentIntents.Create(paymentIntentCreateOptions);

      var paymentIntentClientSecret = paymentIntent.ClientSecret;

      return paymentIntentClientSecret;
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

    private int CalculateAmount(PaymentIntentRequestDTO request)
    {
      // Replace this constant with a calculation of the order's amount
      // Calculate the order total on the server to prevent
      // people from directly manipulating the amount on the client

      switch (request.Subscription)
      {
        case SubscriptionEnum.Bas:
          return 50 * 100;
        case SubscriptionEnum.Portfolio:
          return 150 * 100;
        case SubscriptionEnum.PortfolioPremium:
          return 250 * 100;
        default:
          throw new ArgumentException();
      }
    }
  }
}
