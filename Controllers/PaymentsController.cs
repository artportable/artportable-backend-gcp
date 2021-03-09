using Microsoft.AspNetCore.Mvc;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Artportable.API.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

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
    /// Retrieve prices for all products (plans) from Stripe
    /// </summary>
    /// <returns>A list of prices</returns>
    [HttpGet("prices")]
    public ActionResult<List<StripePriceDTO>> ListPrices()
    {
      try {
        var prices = _paymentService.GetPrices();

        return Ok(prices);
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
    public ActionResult<StripeResponseDTO> CreateCustomer([FromBody] StripeCustomerDTO customer)
    {
      try {
        var id = _paymentService.CreateCustomer(customer.Email, customer.FullName);
        var res = new StripeResponseDTO { Id = id };

        return Ok(res);
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
    public ActionResult<StripeResponseDTO> CreateSubscription([FromBody] SubscriptionRequestDTO req)
    {
      try {
        var id = _paymentService.CreateSubscription(req.PaymentMethod, req.Customer, req.Price);
        var res = new StripeResponseDTO { Id = id };

        return Ok(res);
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