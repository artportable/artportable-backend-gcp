using System;
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
  public class RecommendationsController : ControllerBase
  {
    private readonly IRecommendationService _recommendationService;

    public RecommendationsController(IRecommendationService recommendationService)
    {
      _recommendationService = recommendationService;
    }

    /// <summary>
    /// Get recommendations of users to follow
    /// </summary>
    [HttpGet("")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public ActionResult<RecommendationDTO> Get(Guid userId)
    {
      try {
        var recommendations = _recommendationService.Get(userId);
        
        return Ok(recommendations);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
