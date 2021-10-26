using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StartDeliverController : ControllerBase
  {
    private readonly IStartDeliverService _startDeliverService;
    private readonly string ApiSyncKey = "5F49C523E6B65";

    public StartDeliverController(IStartDeliverService startDeliverService)
    {
      _startDeliverService = startDeliverService;
    }

    /// <summary>
    /// Endpoint for startdeliver api-sync
    /// </summary>
    [HttpGet("api-sync/users")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StartDeliverUserSyncDTO>))]
    public ActionResult<List<StartDeliverUserSyncDTO>> GetUsersToSync(string apiKey, int limit, int offset)
    {
      if(apiKey != ApiSyncKey) {
        return StatusCode(StatusCodes.Status401Unauthorized);
      }

      try {
        var users = _startDeliverService.GetUsersToSync(limit, offset);

        return Ok(users);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
