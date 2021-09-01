using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DiscoverController : ControllerBase
  {
    private readonly IDiscoverService _discoverService;
    private readonly Random _random;

    public DiscoverController(IDiscoverService discoverService)
    {
      _discoverService = discoverService;
      _random = new Random();
    }

    /// <summary>
    /// Get a collection of art
    /// </summary>
    [HttpGet("artworks", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetArtworks(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      string q = null,
      int? seed = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      if (!seed.HasValue)
      {
        seed = _random.Next();
      }

      try
      {
        var artworks = _discoverService.GetArtworks(page, pageSize, tags, myUsername, q, seed.Value);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { seed = seed, tag = tags, myUsername = myUsername }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Get a collection of artists
    /// </summary>
    [HttpGet("artists", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtistDTO>))]
    public ActionResult<List<ArtistDTO>> GetArtists(int page = 1, int pageSize = 10, string q = null, string myUsername = null, int? seed = null)
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      if (!seed.HasValue)
      {
        seed = _random.Next();
      }


      try
      {
        var artists = _discoverService.GetArtists(page, pageSize, q, myUsername, seed.Value);
        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { seed = seed, q = q, myUsername = myUsername }, page, pageSize, artists.Count);
        Response.Headers.Add("Access-Control-Expose-Headers","Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artists);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
