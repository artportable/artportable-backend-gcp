using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArtworksController : ControllerBase
  {
    private readonly IArtworkService _artworkService;
    private readonly IActivityService _activityService;


    public ArtworksController(IArtworkService artworkService, IActivityService activityService)
    {
      _artworkService = artworkService;
      _activityService = activityService;
    }

    /// <summary>
    /// Get a collection of artwork
    /// </summary>
    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> Get(string owner = null, string myUsername = null)
    {
      try
      {
        var artworks = _artworkService.Get(owner, myUsername);

        return Ok(artworks);
      }
      catch (Exception e)
      {
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
      try
      {
        var artwork = _artworkService.Get(id, myUsername);

        if (artwork == null)
        {
          return NotFound();
        }

        return Ok(artwork);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Create a new artwork
    /// </summary>
    [Authorize]
    [HttpPost("")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ArtworkDTO))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ArtworkDTO>> CreateArtwork([FromBody] ArtworkForCreationDTO dto, Guid mySocialId)
    {
      try
      {
        var artwork = _artworkService.Create(dto, mySocialId);

        if (artwork == null)
        {
          return BadRequest();
        }
        await _activityService.CreateArtwork(artwork.Id, artwork.Title, mySocialId);

        return Ok(artwork);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Update an existing artwork
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /
    ///     {
    ///        "title": "Example artwork",
    ///        "description": "This is an example artwork",
    ///        "price": 2000,
    ///        "primaryfile": "batman.jpg",
    ///        "secondaryfile": "robin.jpg",
    ///        "tertiaryfile": "batmanandrobin.jpg",
    ///        "tags": ["oil", "acrylic", "landscape"]
    ///     }
    ///
    /// </remarks>

    [HttpPut("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ArtworkDTO))]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ArtworkDTO>> UpdateArtwork([FromBody] ArtworkForUpdateDTO dto, Guid id, Guid mySocialId)
    {
      try
      {
        var artwork = _artworkService.Update(dto, id, mySocialId);

        if (artwork == null)
        {
          return NotFound();
        }
        await _activityService.UpdateArtwork(artwork.Id, artwork.Title, mySocialId);

        return Ok(artwork);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("updateOrderIndices")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> UpdateArtworksOrderIndices([FromBody] List<ArtworkOrderIndexUpdate> updateOrderIndexDtos)
    {
        try
        {
            foreach (var updateOrderIndexDto in updateOrderIndexDtos)
            {
                var updatedArtwork = _artworkService.UpdateOrderIndex(updateOrderIndexDto.ArtworkId, updateOrderIndexDto.OrderIndex);
            }

            return Ok("Order indices updated successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong, {0}", e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }




    /// <summary>
    /// Delete an artwork
    /// </summary>
    [Authorize]
    [HttpDelete("{id}")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public IActionResult DeleteArtwork(Guid id, string myUsername = null)
    {
      try {
        _artworkService.Delete(id, myUsername);

        return NoContent();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Get all tags
    /// </summary>
    [HttpGet("tags")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<string>))]
    public ActionResult<List<string>> GetTags()
    {
      try
      {
        var tags = _artworkService.GetTags();

        return Ok(tags);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Get the tags of a specific artwork
    /// </summary>
    [HttpGet("{id}/tags")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<TagDTO>))]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<List<TagDTO>> GetTags(Guid id)
    {
      try
      {
        var tags = _artworkService.GetTags(id);

        if (tags == null)
        {
          return NotFound();
        }

        return Ok(tags);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Like a specific artwork
    /// </summary>
    [Authorize]
    [HttpPost("{id}/like")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public IActionResult Like(Guid id, Guid mySocialId)
    {
      try
      {
        Guid creator;

        if (_artworkService.Like(id, mySocialId, out creator))
        {
          _activityService.LikeArtwork(id, mySocialId, creator);
          return Ok();
        }

        return NotFound();
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Unike a liked artwork
    /// </summary>
    [Authorize]
    [HttpDelete("{id}/like")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    public IActionResult Unlike(Guid id, Guid mySocialId)
    {
      try
      {
        Guid owner;
        if (_artworkService.Unlike(id, mySocialId, out owner))
        {
          _activityService.UnLikeArtwork(id, mySocialId, owner);
          return Ok();
        }
        return NotFound();
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
