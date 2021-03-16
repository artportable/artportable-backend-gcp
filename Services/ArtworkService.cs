using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Services
{
  public class ArtworkService : IArtworkService
  {
    private APContext _context;

    public ArtworkService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
    }

    public List<ArtworkDTO> Get()
    {
      var artworks = _context.Artworks
        .Include(a => a.User)
        .Include(a => a.PrimaryFile)
        .Include(a => a.SecondaryFile)
        .Include(a => a.TertiaryFile);
      
      return artworks.Select(a =>
        new ArtworkDTO
        {
          Id = a.PublicId,
          Owner = a.User.Username,
          Title = a.Title,
          Description = a.Description,
          Published = a.Published,
          PrimaryFile = a.PrimaryFile.Name,
          SecondaryFile = a.SecondaryFile != null ? a.SecondaryFile.Name : null,
          TertiaryFile = a.TertiaryFile != null ? a.TertiaryFile.Name : null,
          Tags = a.Tags != null ? a.Tags.Select(t => t.Title).ToList() : new List<string>()
        })
        .ToList();
    }
  }
}
