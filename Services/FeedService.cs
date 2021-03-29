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

    public List<FeedItemDTO<ArtworkPostDTO>> Get(int page, int pageSize, Guid publicUserId)
    {
      var userId = _context.Users.FirstOrDefault(u => u.PublicId == publicUserId).Id;

      var artworks = _context.Artworks
        .Include(a => a.User).ThenInclude(u => u.UserProfile)
        .Include(a => a.User.FolloweeRef)
        .Include(a => a.PrimaryFile)
        .Include(a => a.SecondaryFile)
        .Include(a => a.TertiaryFile)
        .Include(a => a.Likes);

      var res = artworks
        .Where(a => a.UserId == userId || a.User.FolloweeRef.Any(f => f.FollowerId == userId))
        .OrderByDescending(a => a.Published)
        .Skip(pageSize * (page-1))
        .Take(pageSize)
        .Select(a =>
          new FeedItemDTO<ArtworkPostDTO>
          {
            Type = FeedItemType.Artwork,
            User = a.User.Username,
            Location = a.User.UserProfile.Location,
            Published = a.Published,
            Likes = a.Likes.Count(),
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
