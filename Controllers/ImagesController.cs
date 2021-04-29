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
    [SwaggerResponse(StatusCodes.Status200OK)]
    public async Task<IActionResult> Upload()
    {
      var filename = Guid.NewGuid() + ".jpg";
      var stream = _contextAccessor?.HttpContext?.Request?.BodyReader.AsStream();

      try {
        await _awsS3Service.UploadAsync(stream, filename);

        return Ok(filename);
      }
      catch (ArgumentException e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return BadRequest();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Delete an image from AWS S3 bucket
    /// </summary>
    [HttpDelete("{filename}")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(string filename)
    {
      if (filename == null || !filename.EndsWith(".jpg") || !Guid.TryParse(filename.Replace(".jpg", ""), out _))
      {
        return BadRequest();
      }

      try {
        await _awsS3Service.DeleteAsync(filename);

        return NoContent();
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
