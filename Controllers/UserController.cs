using Microsoft.AspNetCore.Mvc;
using Artportable.API.Entities.Model;

namespace Artportable.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    // [Authorize]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Gets the user Kalle Banan
        /// </summary>
        [HttpGet()]
        public IActionResult GetUser()
        {
          var user = new User() { Name = "Kalle Banan" };

          return Ok(user);
        }
    }
}