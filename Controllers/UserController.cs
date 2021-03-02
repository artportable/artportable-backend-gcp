using Microsoft.AspNetCore.Mvc;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Artportable.API.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Artportable.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    // [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IGalleryRepository _galleryRepository;
        private readonly IUserService _userService;

        public UserController(IGalleryRepository galleryRepository, IUserService userService)
        {
            _galleryRepository = galleryRepository;
            _userService = userService;
        }

        [HttpGet("")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
          return Ok("Hej!");
        }

        /// <summary>
        /// Gets a specific user by ID
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public IActionResult Get(Guid id)
        {
          try {
            var user = _userService.Get(id);

            if (user == null) {
              return StatusCode(StatusCodes.Status404NotFound);
            }

            return Ok(user);
          }
          catch (Exception e) {
            Console.WriteLine("Something went wrong, {e]", e);
            return StatusCode(StatusCodes.Status500InternalServerError);
          }
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /
        ///     {
        ///        "username": "batman",
        ///        "name": "Bat",
        ///        "surname": "Man",
        ///        "email": "batman@artportable.com",
        ///        "password": "asecret",
        ///        "dateofbirth": "19790101",
        ///        "location": "Stockholm"
        ///     }
        ///
        /// </remarks>
        /// <param name="user"></param>
        [HttpPost("")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] UserDTO user)
        {
          try {
            var publicId = _userService.CreateUser(user);

            return CreatedAtAction(nameof(Get), new { id = publicId }, user);
          }
          catch (ArgumentException e) {
            Console.WriteLine("Argument not valid, {e]", e);
            return StatusCode(StatusCodes.Status400BadRequest);;
          }
          catch (Exception e) {
            Console.WriteLine("Something went wrong, {e]", e);
            return StatusCode(StatusCodes.Status500InternalServerError);;
          }
        }
    }
}