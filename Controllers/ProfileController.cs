using Microsoft.AspNetCore.Mvc;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Artportable.API.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class ProfileController : ControllerBase
  {
    private readonly IUserService _userService;

    public ProfileController(IUserService userService)
    {
      _userService = userService;
    }

    /// <summary>
    /// Gets a user profile summary by ID for the
    /// profile summary card
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}/summary")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<ProfileSummaryDTO> GetProfileSummary(Guid id)
    {
      try {
        var user = _userService.GetProfileSummary(id);

        if (user == null) {
          return StatusCode(StatusCodes.Status404NotFound);
        }

        return Ok(user);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Gets a specific user profile by ID
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<ProfileDTO> GetProfile(Guid id)
    {
      try {
        var user = _userService.GetProfile(id);

        if (user == null) {
          return StatusCode(StatusCodes.Status404NotFound);
        }

        return Ok(user);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Put (update) to a specific user profile by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="body"></param>
    [HttpPut("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<ProfileDTO> UpdateProfile(Guid id, [FromBody]UpdateProfileDTO body)
    {
      var userProfile = _userService.UpdateProfile(id, body);

      if (userProfile == null) {
        return NotFound();
      }

      return Ok(userProfile);
    }

    /// <summary>
    /// Get a list of similar profiles
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}/similar")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<List<SimilarProfileDTO>> GetSimilarProfiles(Guid id)
    {
      var profiles = _userService.GetSimilarProfiles(id);

      if (profiles == null) {
        return NotFound();
      }

      return Ok(profiles);
    }
  }
}
