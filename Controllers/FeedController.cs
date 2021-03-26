using System;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class FeedController : ControllerBase
  {
    private readonly IFeedService _feedService;

    public FeedController(IFeedService feedService)
    {
      _feedService = feedService;
    }

    /// <summary>
    /// Get feed
    /// </summary>
    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public IActionResult Get(int page, int pageSize = 10)
    {
      if (page < 1 || pageSize < 1) {
        return BadRequest();
      }

      try {
        var feedItems = _feedService.Get(page, pageSize);

        return Ok(feedItems);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
