using System;
using System.Threading.Tasks;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.IO;
using SixLabors.ImageSharp.PixelFormats;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class ImagesController : ControllerBase
  {
    private readonly IImageService _imageService;
    private readonly IUploadService _uploadService;
    private readonly IHttpContextAccessor _contextAccessor;

    public ImagesController(IImageService imageService, IUploadService uploadService, IHttpContextAccessor contextAccessor)
    {
      _imageService = imageService;
      _uploadService = uploadService;
      _contextAccessor = contextAccessor;
    }

    /// <summary>
    /// Upload an image to AWS S3 bucket
    /// </summary>
    /// <param name="w">Width of the image in pixels</param>
    /// <param name="h">Height of the image in pixels</param>
    [HttpPost(Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public async Task<IActionResult> Upload(int w, int h)
    {
      if (w <= 0 || h <= 0)
      {
        return BadRequest();
      }

        var filename = Guid.NewGuid() + ".jpg";
        var stream = _contextAccessor?.HttpContext?.Request?.BodyReader.AsStream();

        try
        {
            using (var image = Image.Load(stream))
            {
                
                var imageEncoder = new JpegEncoder();
                imageEncoder.Quality = 40;
                var compressedStream = new MemoryStream();
                image.Save(compressedStream, imageEncoder);
                compressedStream.Seek(0, SeekOrigin.Begin);
                await _uploadService.UploadAsync(compressedStream, filename);
                _imageService.Add(filename, w, h) ;
            }
            return Ok(filename);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Something went wrong, {0}", e);
            return BadRequest();
        }
        catch (Exception e)
        {
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

      try
      {
        await _uploadService.DeleteAsync(filename);
        _imageService.Remove(filename);

        return NoContent();
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}