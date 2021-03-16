using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Services
{
  public class FeedService : IFeedService
  {
    private APContext _context;

    public FeedService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
    }

    public List<FeedItemDTO<ArtworkPostDTO>> Get()
    {
      var artworks = _context.Artworks
        .Include(a => a.User)
        .ThenInclude(u => u.UserProfile)
        .Include(a => a.PrimaryFile)
        .Include(a => a.SecondaryFile)
        .Include(a => a.TertiaryFile);

      var res = artworks.Select(a =>
          new FeedItemDTO<ArtworkPostDTO>
          {
            Type = FeedItemType.Artwork,
            User = a.User.Username,
            Location = a.User.UserProfile.Location,
            Published = a.Published,
            Item = new ArtworkPostDTO
            {
              Id = a.PublicId,
              PrimaryFile = a.PrimaryFile.Name,
              SecondaryFile = a.SecondaryFile != null ? a.SecondaryFile.Name : null,
              TertiaryFile = a.TertiaryFile != null ? a.TertiaryFile.Name : null,
            }
          })
        .ToList();

      return res;
    }
  }
}
