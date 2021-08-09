using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using Stripe;
using System.IO;
using Artportable.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StripeController : ControllerBase
  {
    private readonly IStripeService _stripeService;
    private readonly string _endpointSecret;

    public StripeController(IStripeService stripeService)
    {
      _stripeService = stripeService;

      // If you are testing your webhook locally with the Stripe CLI you
      // can find the endpoint's secret by running `stripe listen`
      // Otherwise, find your endpoint's secret in your webhook settings
      // in the Developer Dashboard
      _endpointSecret = "whsec_miPqXPLpnoYlk4na5XVv8IApTltIjYn9";
    }

    /// <summary>
    /// Webhook used by Stripe to communicate changes
    /// </summary>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Webhook()
    {
      try
      {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        // Construct event and verify signature
        var stripeEvent = EventUtility.ConstructEvent(
          json,
          Request.Headers["Stripe-Signature"],
          _endpointSecret
        );

        _stripeService.HandleEvent(stripeEvent);

        return Ok();
      }
      catch (StripeException)
      {
        return BadRequest("Failed to verify signature.");
      }
      catch (Exception e) {
        // Log error and send 500 back to Stripe so that they'll retry
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
