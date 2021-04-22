using System;
using System.IO;
using System.Threading.Tasks;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class ImagesController : ControllerBase
  {
    private readonly IAwsS3Service _awsS3Service;
    private readonly IHttpContextAccessor _contextAccessor;

    public ImagesController(IAwsS3Service awsS3Service, IHttpContextAccessor contextAccessor)
    {
      _awsS3Service = awsS3Service;
      _contextAccessor = contextAccessor;
    }

    /// <summary>
    /// Upload an image to AWS S3 bucket
    /// </summary>
    [HttpPost("")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Upload(string filename)
    {
      var stream = _contextAccessor?.HttpContext?.Request?.BodyReader.AsStream();
      if (stream == null || filename == null)
      {
        return BadRequest();
      }

      try {
        await _awsS3Service.UploadAsync(stream, filename);

        return NoContent();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
