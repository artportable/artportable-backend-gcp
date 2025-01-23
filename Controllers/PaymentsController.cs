using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
                var id = _paymentService.CreateCustomer(
                    customer.Email,
                    customer.FullName,
                    customer.PhoneNumber
                );
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
        public ActionResult<StripeSubscriptionResponseDTO> CreateSubscription(
            [FromBody] SubscriptionRequestDTO req
        )
        {
            try
            {
                var subscription = _paymentService.CreateSubscription(
                    req.PaymentMethod,
                    req.Customer,
                    req.Price,
                    req.PromotionCodeId
                );

                // Assuming _paymentService.CreateSubscription handles the interaction with Stripe and returns a subscription object.

                if (subscription == null)
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        "Failed to create subscription."
                    );
                }

                if (subscription.Status == "active" || subscription.Status == "trialing")
                {
                    var responseDTO = new StripeSubscriptionResponseDTO
                    {
                        Status = subscription.Status,
                        Id = subscription.Id,
                        ClientSecret =
                            subscription.Status == "requires_action"
                            && subscription.LatestInvoice?.PaymentIntent != null
                                ? subscription.LatestInvoice.PaymentIntent.ClientSecret
                                : null,
                    };

                    return Ok(responseDTO);
                }
                else
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        $"Subscription is in an unexpected state: {subscription.Status}"
                    );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while creating the subscription."
                );
            }
        }

        /// <summary>
        /// Upgrades a customersubscription in Stripe
        /// for a given customer and price ID
        /// </summary>
        /// <param name="req"></param>
        /// <returns>The Stripe subscription ID</returns>
        [Authorize]
        [HttpPost("upgrade")]
        public ActionResult<StripeSubscriptionResponseDTO> UpgradeSubscription(
            [FromBody] SubscriptionRequestDTO req
        )
        {
            try
            {
                var subscription = _paymentService.UpgradeSubscription(
                    req.PaymentMethod,
                    req.Customer,
                    req.Price,
                    req.PromotionCodeId
                );

                if (subscription?.LatestInvoice?.PaymentIntent == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                var res = new StripeSubscriptionResponseDTO
                {
                    Status = subscription.LatestInvoice.PaymentIntent.Status,
                    Id =
                        subscription.LatestInvoice.PaymentIntent.Status == "requires_action"
                            ? subscription.LatestInvoice.PaymentIntent.ClientSecret
                            : subscription.Id,
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
        public async Task<ActionResult<StripePurchaseResponseDTO>> CreatePurchase(
            [FromBody] PurchaseRequestDTO req
        )
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
                if (
                    req.Customer == null
                    || string.IsNullOrWhiteSpace(req.Customer.Email)
                    || string.IsNullOrWhiteSpace(req.Customer.FullName)
                )
                {
                    return BadRequest("Invalid Customer");
                }
                var customerId = _paymentService.CreateCustomer(
                    req.Customer.Email,
                    req.Customer.FullName,
                    req.Customer.PhoneNumber
                );

                var invoice = await _paymentService.CreateInvoice(
                    req.PaymentMethod,
                    customerId,
                    req.Products
                );

                if (invoice.PaymentIntent == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                var res = new StripePurchaseResponseDTO
                {
                    Status = invoice.PaymentIntent.Status,
                    Id =
                        invoice.PaymentIntent.Status == "requires_action"
                        || invoice.PaymentIntent.Status == "requires_confirmation"
                            ? invoice.PaymentIntent.ClientSecret
                            : invoice.Id,
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

        /// <summary>
        /// Creates a Stripe Customer Portal session for a given customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer to create a portal session for.</param>
        /// <returns>A redirect URL to the Stripe Customer Portal.</returns>

        [HttpGet("customers/{customerId}/portal-session")]
        public ActionResult CreateCustomerPortalSession(string customerId)
        {
            try
            {
                var session = _paymentService.CreateCustomerPortalSession(customerId);
                if (session == null || string.IsNullOrEmpty(session.Url))
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        "Failed to create customer portal session."
                    );
                }

                return Ok(new { Url = session.Url });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while creating the customer portal session."
                );
            }
        }

        /// <summary>
        /// Boosts an artwork
        /// </summary>
        /// <param name="boostRequest">Boost request containing artwork ID and payment method ID.</param>
        /// <returns>ActionResult indicating success or failure of boosting artwork.</returns>
        [HttpPost("boost")]
        public async Task<ActionResult> BoostArtwork([FromBody] BoostRequestDTO boostRequest)
        {
            try
            {
                var isBoosted = await _paymentService.BoostArtwork(
                    boostRequest.PaymentMethodId,
                    boostRequest.CustomerId,
                    boostRequest.ArtworkId
                );
                if (isBoosted)
                {
                    return Ok("Artwork boosted successfully.");
                }
                else
                {
                    return BadRequest("Failed to boost artwork.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error boosting artwork: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Boosts a story/exhibition
        /// </summary>
        /// <param name="boostRequest">Boost request containing artwork ID and payment method ID.</param>
        /// <returns>ActionResult indicating success or failure of boosting artwork.</returns>
        [HttpPost("boostStory")]
        public async Task<ActionResult> BoostStory([FromBody] BoostStoryRequestDTO boostRequest)
        {
            try
            {
                var isBoosted = await _paymentService.BoostStory(
                    boostRequest.PaymentMethodId,
                    boostRequest.CustomerId,
                    boostRequest.StoryId
                );
                if (isBoosted)
                {
                    return Ok("Artwork boosted successfully.");
                }
                else
                {
                    return BadRequest("Failed to boost artwork.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error boosting artwork: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
