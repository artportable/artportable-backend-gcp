using System;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;


namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
//   [Authorize] // Kommenterar ut medan jag testar runt.
  [ApiController]
  public class ArtistsController : ControllerBase
  {
    private readonly IUserService _userService;

    public ArtistsController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public ActionResult<UserDTO> GetArtists()    // Ej async?
    {
        var profiles = _userService.GetAllArtists();
        return Ok(profiles);
    }


// NAME och surname. Använd username som link.
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
  }
}