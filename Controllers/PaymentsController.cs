using Microsoft.AspNetCore.Mvc;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Artportable.API.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

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
      try
      {
        var prices = _paymentService.GetPrices();

        return Ok(prices);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Register a customer in Stripe by creating a customer object
    /// </summary>
    /// <param name="customer"></param>
    /// <returns>The Stripe customer ID</returns>
    [Authorize]
    [HttpPost("customers")]
    public ActionResult<StripeResponseDTO> CreateCustomer([FromBody] StripeCustomerDTO customer)
    {
      try
      {
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
    [Authorize]
    [HttpPost("subscriptions")]
    public ActionResult<StripeSubscriptionResponseDTO> CreateSubscription([FromBody] SubscriptionRequestDTO req)
    {
      try
      {
        var subscription = _paymentService.CreateSubscription(req.PaymentMethod, req.Customer, req.Price, req.PromotionCodeId);

        if (subscription?.LatestInvoice?.PaymentIntent == null)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }

        var res = new StripeSubscriptionResponseDTO
        {
          Status = subscription.LatestInvoice.PaymentIntent.Status,
          Id = subscription.LatestInvoice.PaymentIntent.Status == "requires_action" ?
            subscription.LatestInvoice.PaymentIntent.ClientSecret :
            subscription.Id
        };

        return Ok(res);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Creates a purchase in Stripe
    /// for a given customer and price ID
    /// </summary>
    /// <param name="req"></param>
    /// <returns>The Stripe subscription ID</returns>
    [HttpPost("purchases")]
    public async Task<ActionResult<StripePurchaseResponseDTO>> CreatePurchase([FromBody] PurchaseRequestDTO req)
    {
      try
      {
        if (!req.Products.Any())
        {
          return BadRequest("No products");
        }

        if (!await _paymentService.ValidatePaymentMethod(req.PaymentMethod))
        {
          return BadRequest("Invalid paymentrequest");
        }

        if (!await _paymentService.ValidateProducts(req.Products))
        {
          return BadRequest("Invalid products");
        }
        if (req.Customer == null || string.IsNullOrWhiteSpace(req.Customer.Email) || string.IsNullOrWhiteSpace(req.Customer.FullName))
        {
          return BadRequest("Invalid Customer");
        }
        var customerId = _paymentService.CreateCustomer(req.Customer.Email, req.Customer.FullName);

        var invoice = await _paymentService.CreateInvoice(req.PaymentMethod, customerId, req.Products);

        if (invoice.PaymentIntent == null)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }

        var res = new StripePurchaseResponseDTO
        {
          Status = invoice.PaymentIntent.Status,
          Id = invoice.PaymentIntent.Status == "requires_action" ?
            invoice.PaymentIntent.ClientSecret :
            invoice.Id
        };

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
    [Authorize]
    [HttpDelete("subscriptions")]
    public IActionResult CancelSubscription(string subscriptionId)
    {
      try
      {
        _paymentService.CancelSubscription(subscriptionId);

        return Ok();
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Updates a subscription in Stripe
    /// </summary>
    /// <param name="subscriptionId"></param>
    /// <param name="priceId"></param>
    [Authorize]
    [HttpPut("subscriptions")]
    public IActionResult UpdateSubscription(string subscriptionId, string priceId)
    {
      try
      {
        _paymentService.UpdateSubscription(subscriptionId, priceId);

        return Ok();
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Gets the promotion details for a given promotion code
    /// </summary>
    /// <param name="promotionCode"></param>
    [Authorize]
    [HttpGet("promotions")]
    public IActionResult GetPromotion(string promotionCode)
    {
      try
      {
        var promotion = _paymentService.GetPromotion(promotionCode);

        return Ok(promotion);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}