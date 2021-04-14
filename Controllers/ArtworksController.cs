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
    public ActionResult<List<ArtworkDTO>> Get(string owner = null, string myUsername = null)
    {
      try {
        var artworks = _artworkService.Get(owner, myUsername);

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
    public ActionResult<ArtworkDTO> GetArtwork(Guid id, string myUsername = null)
    {
      try {
        var artwork = _artworkService.Get(id, myUsername);

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
    /// Get the tags of a specific artwork
    /// </summary>
    [HttpGet("{id}/tags")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TagDTO))]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<List<TagDTO>> GetTags(Guid id)
    {
      try {
        var tags = _artworkService.GetTags(id);

        if (tags == null)
        {
          return NotFound();
        }

        return Ok(tags);
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
    public IActionResult Like(Guid id, Guid userId)
    {
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
    public IActionResult Unlike(Guid id, Guid userId)
    {
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
