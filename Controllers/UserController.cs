using Microsoft.AspNetCore.Mvc;
using Artportable.API.Services;

namespace Artportable.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    // [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IGalleryRepository _galleryRepository;

        public UserController(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        [HttpGet("imgs")]
        public IActionResult GetImages()
        {
            var images = _galleryRepository.GetImages();
            return Ok(images);
        }

        [HttpGet("")]
        public IActionResult GetUsers()
        {
            var users = _galleryRepository.GetUsers();
            return Ok(users);
        }

        /// <summary>
        /// Gets the user Kalle Banan
        /// </summary>
        [HttpGet("kalle")]
        public IActionResult GetKalle()
        {
          var user = new TestUser() { Name = "Kalle Banan" };

          return Ok(user);
        }
    }

    public class TestUser
    {
        public string Name { get; set; }
    }
}