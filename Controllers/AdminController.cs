using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Enums;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITrackService _trackService;
        private readonly IAdminService _adminService; // Add the AdminService dependency

        public AdminController(
            IUserService userService,
            ITrackService trackService,
            IAdminService adminService
        )
        {
            _userService = userService;
            _trackService = trackService;
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        /// <summary>
        /// Gets all users matching the given criterias
        /// </summary>
        /// <param name="q"></param>
        [HttpGet("")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public ActionResult<List<TinyUserDTO>> Search(string q)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(q))
                {
                    return new List<TinyUserDTO>();
                }

                var users = _userService.Search(q);

                return Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets statistics for the admin dashboard
        /// </summary>
        [HttpGet("statistics")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the admin statistics")]
        public ActionResult<AdminStatisticsDTO> GetStatistics()
        {
            try
            {
                var statistics = _adminService.GetStatistics();
                return Ok(statistics);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching statistics: {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets product statistics for the admin dashboard
        /// </summary>
        [HttpGet("productStatistics")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the product statistics")]
        public ActionResult<List<AdminStatisticsDTO>> GetProductStatistics()
        {
            try
            {
                var productStatistics = _adminService.GetProductStatistics();
                return Ok(productStatistics);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching product statistics: {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets users associated with a specific product
        /// </summary>
        [HttpGet("usersByProduct/{productId}")]
        [SwaggerResponse(
            StatusCodes.Status200OK,
            "Returns users associated with the specified product"
        )]
        public ActionResult<List<UserDTO>> GetUsersByProduct(int productId)
        {
            try
            {
                var usersWithProduct = _adminService.GetUsersByProduct(productId);
                return Ok(usersWithProduct);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching users by product: {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets users associated with a specific product
        /// </summary>
        [HttpGet("UsersByProductSubscription/{productId}")]
        [SwaggerResponse(
            StatusCodes.Status200OK,
            "Returns users associated with the specified product"
        )]
        public ActionResult<List<UserDTO>> GetUsersByProductSubscription(int productId)
        {
            try
            {
                var usersWithProduct = _adminService.GetUsersByProductSubscription(productId);
                return Ok(usersWithProduct);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching users by product: {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("UsersByStripeSubscription/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUsersByStripeSubscription(string customerId)
        {
            try
            {
                // Use _adminService here
                var usersWithStripe = _adminService.GetCustomerJson(customerId);

                if (usersWithStripe != null)
                {
                    // Handle the result accordingly
                    return Ok(usersWithStripe);
                }
                else
                {
                    return NotFound(); // Or return an appropriate response for not finding the customer
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching users by product: {e}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets a user by email and checks if they have an active subscription on Stripe.
        /// </summary>
        /// <param name="email">The email of the user to check for an active Stripe subscription.</param>
        /// <returns>Returns user details with subscription info if an active subscription exists, otherwise returns 404.</returns>
        [HttpGet("UserWithActiveStripeSubscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserWithActiveStripeSubscription(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest("Email is required.");
                }

                // Use _adminService to check if the user has an active Stripe subscription
                var userWithSubscription =
                    await _adminService.GetUserWithActiveOrTrialingStripeSubscriptionByEmailAsync(
                        email
                    );

                if (userWithSubscription != null)
                {
                    return Ok(userWithSubscription);
                }
                else
                {
                    return NotFound("No active subscription found for the given email.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching active subscription by email: {e}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching the user with active subscription."
                );
            }
        }
    }
}
