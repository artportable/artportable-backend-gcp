using System;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class ActivityController : ControllerBase
  {
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
      _activityService = activityService;
    }

    /// <summary>
    /// TEST: Register user
    /// </summary>
    [HttpGet("connect")]
    public ActionResult<string> Connect(string userId)
    {
      try {
        var token = _activityService.ConnectUser(userId);

        return Ok(token);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
