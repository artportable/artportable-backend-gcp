using System;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
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
    public ActionResult<RecommendationDTO> Get(Guid userId)
    {
      try {
        var recommendations = _connectionService.GetRecommendations(userId);

        if (recommendations == null)
          return BadRequest();

        return Ok(recommendations);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
