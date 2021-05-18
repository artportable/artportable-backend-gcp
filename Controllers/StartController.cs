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
  // [Authorize]
  public class StartController : ControllerBase
  {
    private readonly IStartService _startService;

    public StartController(IStartService startService)
    {
      _startService = startService;
    }

    /// <summary>
    /// Get a set of artworks for start page
    /// </summary>
    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<UserImageDTO>))]
    public ActionResult<List<UserImageDTO>> Get()
    {
      try {
        var userImages = _startService.Get();

        return Ok(userImages);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
