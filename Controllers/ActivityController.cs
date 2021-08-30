using System;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
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
    public ActionResult<string> Connect(string username)
    {
      try {
        var token = _activityService.ConnectUser(username);

        return Ok(token);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Test: create activity
    /// </summary>
    [HttpPost("create")]
    public ActionResult<string> Create(string username)
    {
      try {
        _activityService.CreateActivity();

        return Ok();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// TEST: Register user
    /// </summary>
    [HttpGet("")]
    public ActionResult<string> Test(string username)
    {
      try {
        var token = _activityService.GetFeed(username);

        return Ok(token);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
