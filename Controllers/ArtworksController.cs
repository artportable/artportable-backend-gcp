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
    [SwaggerResponse(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Like a specific artwork
    /// </summary>
    [HttpPost("{id}/like")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public IActionResult Like(Guid id)
    {
      // TODO: Pick from session
      Guid userId = new Guid("b2ca9be2-f852-4d65-9498-c43366996352");

      try {
        var res = _artworkService.Like(id, userId);

        if (res == false)
        {
          return NotFound();
        }

        return Ok();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Unike a liked artwork
    /// </summary>
    [HttpDelete("{id}/like")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    public IActionResult Unlike(Guid id)
    {
      // TODO: Pick from session
      Guid userId = new Guid("b2ca9be2-f852-4d65-9498-c43366996352");

      try {
        _artworkService.Unlike(id, userId);

        return Ok();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
