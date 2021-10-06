using System;
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
  [Authorize]
  [ApiController]
  public class ConnectionsController : ControllerBase
  {
    private readonly IConnectionService _connectionService;
    private readonly IActivityService _activityService;

    public ConnectionsController(IConnectionService connectionService, IActivityService activityService)
    {
      _connectionService = connectionService;
      _activityService = activityService;
    }

    /// <summary>
    /// Get recommendations of users to follow
    /// </summary>
    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public ActionResult<RecommendationDTO> Get(string myUsername)
    {
      try
      {
        var recommendations = _connectionService.GetRecommendations(myUsername);

        if (recommendations == null)
          return BadRequest();

        return Ok(recommendations);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Follow a user
    /// </summary>
    [HttpPost("{socialId}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Follow(Guid socialId, Guid mySocialId)
    {
      try
      {
        var result = _connectionService.Follow(socialId, mySocialId);
        await _activityService.Follow(mySocialId, socialId);

        if (!result)
          return BadRequest();

        return Ok();
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Unfollow a user
    /// </summary>
    [HttpDelete("{socialId}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public async Task<IActionResult> Unfollow(Guid socialId, Guid mySocialId)
    {
      try
      {
        _connectionService.Unfollow(socialId, mySocialId);
        await _activityService.UnFollow(mySocialId, socialId);

        return Ok();
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
