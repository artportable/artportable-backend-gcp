using System;
using System.IO;
using System.Threading.Tasks;
using Artportable.API.Options;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace Artportable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService _stripeService;
        private readonly string _endpointSecret;

        public StripeController(
            IStripeService stripeService,
            IOptions<StripeOptions> stripeSettings
        )
        {
            _stripeService = stripeService;

            // If you are testing your webhook locally with the Stripe CLI you
            // can find the endpoint's secret by running `stripe listen`
            // Otherwise, find your endpoint's secret in your webhook settings
            // in the Developer Dashboard
            _endpointSecret = stripeSettings.Value.WebhookSecret;
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
                    _endpointSecret,
                    throwOnApiVersionMismatch: false // Temporary fix to allow events from older API webhook
                );

                _stripeService.HandleEvent(stripeEvent);

                return Ok();
            }
            catch (StripeException e)
            {
                if (e.Message.Contains("Received event with API version"))
                {
                    return BadRequest("Stripe API version error: " + e);
                }
                else
                {
                    return BadRequest("Failed to verify signature.");
                }
            }
            catch (InvalidOperationException)
            {
                return BadRequest("No customer with given customer ID found.");
            }
            catch (Exception e)
            {
                // Log error and send 500 back to Stripe so that they'll retry
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
