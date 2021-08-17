using System;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [Authorize]
  [ApiController]
  public class ConnectionsController : ControllerBase
  {
    private readonly IConnectionService _connectionService;

    public ConnectionsController(IConnectionService connectionService)
    {
      _connectionService = connectionService;
    }

    /// <summary>
    /// Get recommendations of users to follow
    /// </summary>
    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public ActionResult<RecommendationDTO> Get(string myUsername)
    {
      try {
        var recommendations = _connectionService.GetRecommendations(myUsername);

        if (recommendations == null)
          return BadRequest();

        return Ok(recommendations);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Follow a user
    /// </summary>
    [HttpPost("{username}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public IActionResult Follow(string username, string myUsername)
    {
      try {
        var result = _connectionService.Follow(username, myUsername);

        if (!result)
          return BadRequest();

        return Ok();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Unfollow a user
    /// </summary>
    [HttpDelete("{username}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public IActionResult Unfollow(string username, string myUsername)
    {
      try {
        _connectionService.Unfollow(username, myUsername);

        return Ok();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
