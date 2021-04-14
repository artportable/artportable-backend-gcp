using Microsoft.AspNetCore.Mvc;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Artportable.API.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    /// <summary>
    /// Checks whether the given input (username OR email) is free or already in use
    /// Example: GET /api/user?email=kalle@artportable.com
    /// </summary>
    /// <param name="username"></param>
    /// <param name="email"></param>
    /// <returns>True if it's free, false otherwise</returns>
    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public IActionResult Get(string username = null, string email = null)
    {
      try {
        if (username != null)
        {
          return Ok(!_userService.UsernameExists(username));
        }
        else if (email != null)
        {
          return Ok(!_userService.EmailExists(email));
        }
        else
        {
          return BadRequest();
        }
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Gets a specific user by username
    /// </summary>
    /// <param name="username"></param>
    [HttpGet("{username}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<UserDTO> Get(string username)
    {
      try {
        var user = _userService.Get(username);

        if (user == null) {
          return StatusCode(StatusCodes.Status404NotFound);
        }

        return Ok(user);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
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
    ///        "dateofbirth": "1979-01-01",
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
      if (_userService.UserExists(user))
      {
        return StatusCode(StatusCodes.Status409Conflict, "User already exists");
      }

      try {
        var publicId = _userService.CreateUser(user);

        return CreatedAtAction(nameof(Get), new { id = publicId }, user);
      }
      catch (ArgumentException e) {
        Console.WriteLine("Argument not valid, {0}", e);
        return StatusCode(StatusCodes.Status400BadRequest);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }


    [HttpGet("login")]
    public IActionResult Login(string email)
    {
      var userId = _userService.Login(email);

      if (userId == null) {
        return NotFound();
      }

      var res = new UserId() { Id = (Guid) userId };

      return Ok(res);
    }
  }

  public class UserId
  {
    public Guid Id { get; set; }
  }
}