using System;
using System.Linq;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;

namespace Artportable.API.Services
{
  public class ImageService : IImageService
  {
    private APContext _context;

    public ImageService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
    }

    /// <summary>
    /// Add new image
    /// </summary>
    public void Add(string filename, int width, int height)
    {
      var file = new File
      {
        Name = filename,
        Width = width,
        Height = height
      };

      _context.Files.Add(file);
      _context.SaveChanges();
    }

    public void Remove(string filename)
    {
      var file = _context.Files.FirstOrDefault(x => x.Name == filename);
      if(file == null){
        throw new Exception($"File with name {filename} does not exist");
      }
      _context.Files.Remove(file);
    }
  }
}
