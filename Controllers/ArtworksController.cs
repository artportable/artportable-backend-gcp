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
  public class ArtworksController : ControllerBase
  {
    private readonly IArtworkService _artworkService;

    public ArtworksController(IArtworkService artworkService)
    {
      _artworkService = artworkService;
    }

    /// <summary>
    /// Get a collection of artwork
    /// </summary>
    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> Get()
    {
      try {
        var artworks = _artworkService.Get();

        return Ok(artworks);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Get a specific artwork
    /// </summary>
    [HttpGet("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ArtworkDTO))]
    public ActionResult<ArtworkDTO> Get(Guid id)
    {
      try {
        var artwork = _artworkService.Get(id);

        if (artwork == null)
        {
          return NotFound();
        }

        return Ok(artwork);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
