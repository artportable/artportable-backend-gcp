using Artportable.API.DTOs;
using Artportable.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artportable.API.Services
{
  public class StartService : IStartService
  {
    private APContext _context;

    public StartService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
    }

    public List<UserImageDTO> Get()
    {
      var artworks = _context.Artworks
        .Include(a => a.PrimaryFile)
        .Include(a => a.User)
        .ThenInclude(u => u.File)
        .Include(a => a.Likes);

      var userImages = artworks
        .Where(a => (a.PrimaryFile.Width / a.PrimaryFile.Height) < 1.5)
        .OrderByDescending(a => a.Likes.Count())
        .Take(18)
        .OrderBy(a => a.PrimaryFile.Width / a.PrimaryFile.Height) // Sortera Bred >> Hög
        .Select(a => new UserImageDTO {
          Image = new FileDTO {
            Name = a.PrimaryFile.Name,
            Width = a.PrimaryFile.Width,
            Height = a.PrimaryFile.Height,
          },
          Username = a.User.Username,
          ProfilePicture = a.User.File.Name
        })
        .ToList();

      return userImages;
    }
  }
}
