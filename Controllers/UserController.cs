using Microsoft.AspNetCore.Mvc;
using Artportable.API.Entities.Model;

namespace Artportable.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    // [Authorize]
    public class UserController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetUser()
        {
          var user = new User() { Name = "Kalle Banan" };

          return Ok(user);
        }
    }
}