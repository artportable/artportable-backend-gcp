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
  public class DiscoverController : ControllerBase
  {
    private readonly IDiscoverService _discoverService;

    public DiscoverController(IDiscoverService discoverService)
    {
      _discoverService = discoverService;
    }

    /// <summary>
    /// Get a collection of art
    /// </summary>
    [HttpGet("artworks")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> Get(int page, int pageSize = 10, string myUsername = null)
    {
      if (page < 1 || pageSize < 1) {
        return BadRequest();
      }

      try {
        var artists = _discoverService.GetArtworks(page, pageSize, myUsername);

        return Ok(artists);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Get a collection of artists
    /// </summary>
    [HttpGet("artists")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtistDTO>))]
    public ActionResult<List<ArtistDTO>> Get(string myUsername = null)
    {
      try {
        var artists = _discoverService.GetArtists(myUsername);

        return Ok(artists);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
