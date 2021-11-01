using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Options;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StartDeliverController : ControllerBase
  {
    private readonly IStartDeliverService _startDeliverService;
    private readonly StartDeliverOptions _startDeliverOptions;

    public StartDeliverController(IStartDeliverService startDeliverService,  IOptions<StartDeliverOptions> startDeliverOptions)
    {
      _startDeliverService = startDeliverService;
      _startDeliverOptions = startDeliverOptions.Value;
    }

    /// <summary>
    /// Endpoint for startdeliver api-sync
    /// </summary>
    [HttpGet("sync/users")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StartDeliverUserSyncDTO>))]
    public ActionResult<List<StartDeliverUserSyncDTO>> GetUsersToSync(string apiKey, int limit, int offset)
    {
      if(apiKey != _startDeliverOptions.ApiSyncKey) {
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
