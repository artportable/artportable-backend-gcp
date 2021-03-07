using Microsoft.AspNetCore.Mvc;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Artportable.API.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Text.Json;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class PaymentsController : ControllerBase
  {
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
      _paymentService = paymentService;
    }

    /// <summary>
    /// Create a payment intent through Stripe
    /// </summary>
    /// <param name="request"></param>
    [HttpPost("")]
    [SwaggerResponse(StatusCodes.Status201Created)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public ActionResult<string> Create(PaymentIntentRequestDTO request)
    {
      try {
        var paymentIntentClientSecret = _paymentService.CreateIntent(request);

        return JsonSerializer.Serialize(new { clientSecret = paymentIntentClientSecret });
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Register a customer in Stripe by creating a customer object
    /// </summary>
    /// <param name="customer"></param>
    /// <returns>The Stripe customer ID</returns>
    [HttpPost("customers")]
    public IActionResult CreateCustomer([FromBody] StripeCustomerDTO customer)
    {
      try {
        var id = _paymentService.CreateCustomer(customer.Email, customer.FullName);

        return Ok(id);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Creates a subscription in Stripe
    /// for a given customer and price ID
    /// </summary>
    /// <param name="req"></param>
    /// <returns>The Stripe subscription ID</returns>
    [HttpPost("subscriptions")]
    public IActionResult CreateSubscription([FromBody] SubscriptionRequestDTO req)
    {
      try {
        var id = _paymentService.CreateSubscription(req.PaymentMethod, req.Customer, req.Price);

        return Ok(id);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Cancels a subscription in Stripe
    /// </summary>
    /// <param name="subscriptionId"></param>
    [HttpDelete("subscriptions")]
    public IActionResult CancelSubscription(string subscriptionId)
    {
      try {
        _paymentService.CancelSubscription(subscriptionId);

        return Ok();
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}