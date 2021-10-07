using Microsoft.AspNetCore.Mvc;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Artportable.API.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
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
    /// Get followers of a user
    /// </summary>
    /// <param name="username"></param>
    [HttpGet("{username}/followers")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<List<TinyUserDTO>> GetFollowers(string username)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(username))
        {
          return NotFound();
        }

        var users = _userService.GetFollowers(username);

        return Ok(users);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Gets all users that a user is following
    /// </summary>
    /// <param name="username"></param>
    [HttpGet("{username}/followees")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<List<TinyUserDTO>> GetFollewees(string username)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(username))
        {
          return NotFound();
        }

        var users = _userService.GetFollowees(username);

        return Ok(users);
      }
      catch (Exception e)
      {
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
      try
      {
        var user = _userService.Get(username);

        if (user == null)
        {
          return StatusCode(StatusCodes.Status404NotFound);
        }

        return Ok(user);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Gets a username by socialId
    /// </summary>
    /// <param name="socialId"></param>
    [HttpGet("username")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<string> Get(Guid socialId)
    {
      try
      {
        if (socialId.Equals(new Guid()))
        {
          return StatusCode(StatusCodes.Status404NotFound);
        }

        var username = _userService.GetUsername(socialId);

        if(username == null)
        {
          return StatusCode(StatusCodes.Status404NotFound);
        }

        return Ok(username);
      }
      catch (Exception e)
      {
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
    ///        "email": "batman@artportable.com"
    ///     }
    ///
    /// </remarks>
    /// <param name="user"></param>
    [Authorize]
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] UserDTO user)
    {
      if (_userService.UserExists(user))
      {
        return StatusCode(StatusCodes.Status409Conflict, "User already exists");
      }

      try
      {
        var username = _userService.CreateUser(user);

        return CreatedAtAction(nameof(Get), new { username = username }, user);
      }
      catch (ArgumentException e)
      {
        Console.WriteLine("Argument not valid, {0}", e);
        return StatusCode(StatusCodes.Status400BadRequest);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [Authorize]
    [HttpGet("login")]
    public ActionResult<TinyUserDTO> Login(string email)
    {
      var tinyUser = _userService.Login(email);

      return Ok(tinyUser);
    }
  }
}