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
    /// Gets a user profile summary by username for the
    /// profile summary card
    /// </summary>
    /// <param name="username"></param>
    [HttpGet("{username}/summary")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<ProfileSummaryDTO> GetProfileSummary(string username)
    {
      try {
        var user = _userService.GetProfileSummary(username);

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
    /// Gets a specific user profile by username
    /// </summary>
    /// <param name="username"></param>
    /// <param name="myUsername">OPTIONAL</param>
    [HttpGet("{username}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<ProfileDTO> GetProfile(string username, string myUsername = null)
    {
      try {
        var user = _userService.GetProfile(username, myUsername);

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
    /// <param name="username"></param>
    /// <param name="body"></param>
    [HttpPut("{username}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<ProfileDTO> UpdateProfile(string username, [FromBody]UpdateProfileDTO body)
    {
      var userProfile = _userService.UpdateProfile(username, body);

      if (userProfile == null) {
        return NotFound();
      }

      return Ok(userProfile);
    }

    /// <summary>
    /// Get a list of similar profiles
    /// </summary>
    /// <param name="username"></param>
    [HttpGet("{username}/similar")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<List<SimilarProfileDTO>> GetSimilarProfiles(string username)
    {
      var profiles = _userService.GetSimilarProfiles(username);

      if (profiles == null) {
        return NotFound();
      }

      return Ok(profiles);
    }

    /// <summary>
    /// Gets all tags that are associated with a user through his artworks
    /// </summary>
    /// <param name="username"></param>
    [HttpGet("{username}/tags")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<List<TagDTO>> GetTags(string username)
    {
      try {
        var user = _userService.GetTags(username);

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
    /// Get the profile picture of a user
    /// </summary>
    /// <param name="username"></param>
    [HttpGet("{username}/profilepicture")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<string> GetProfilePicture(string username)
    {
      try {
        var path = _userService.GetProfilePicture(username);

        if (path == null) {
          return StatusCode(StatusCodes.Status404NotFound);
        }

        return Ok(path);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Update the profile picture of a user
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="username"></param>
    [HttpPut("{username}/profilepicture")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<string> UpdateProfilePicture(string filename, string username)
    {
      try {
        _userService.UpdateProfilePicture(filename, username);

        return NoContent();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
