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

    public List<FeedItemDTO<ArtworkPostDTO>> Get(int page, int pageSize, string myUsername)
    {
      var userId = _context.Users.FirstOrDefault(u => u.Username == myUsername).Id;

      var artworks = _context.Artworks
        .Select(a => new 
        {
          UserId= a.UserId,
          User = new {
            Username = a.User.Username,
            FolloweeRef = a.User.FolloweeRef,
            FileName = a.User.File.Name,
            Location = a.User.UserProfile.Location
          },
          Likes = a.Likes.Select(
              l => new {
                UserId = l.UserId
              }
            ).ToList(),
          Published = a.Published,
          PublicId = a.PublicId,
          Title = a.Title,
          PrimaryFile = new {
              Name = a.PrimaryFile.Name,
              Width = a.PrimaryFile.Width,
              Height = a.PrimaryFile.Height
            },
          SecondaryFile = a.SecondaryFile != null ? new {
            Name = a.SecondaryFile.Name,
            Width = a.SecondaryFile.Width,
            Height = a.SecondaryFile.Height
          }: null, 
          TertiaryFile = a.TertiaryFile != null ? new {
            Name = a.TertiaryFile.Name,
            Width = a.TertiaryFile.Width,
            Height = a.TertiaryFile.Height
          }: null
        })
        .Where(a => a.UserId == userId || a.User.FolloweeRef.Any(f => f.FollowerId == userId))
        .OrderByDescending(a => a.Published)
        .Skip(pageSize * (page-1))
        .Take(pageSize)
        .ToList();

      var res = artworks
        .Select(a =>
          new FeedItemDTO<ArtworkPostDTO>
          {
            Type = FeedItemType.Artwork,
            User = a.User.Username,
            ProfilePicture = a.User.FileName,
            Location = a.User.Location,
            Published = a.Published,
            Likes = a.Likes.Count(),
            LikedByMe = a.Likes.Any(l => l.UserId == userId),
            Item = new ArtworkPostDTO
            {
              Id = a.PublicId,
              Title = a.Title,
              PrimaryFile = new FileDTO {
                Name = a.PrimaryFile.Name,
                Width = a.PrimaryFile.Width,
                Height = a.PrimaryFile.Height
              },
              SecondaryFile = a.SecondaryFile != null ? new FileDTO {
                Name = a.SecondaryFile.Name,
                Width = a.SecondaryFile.Width,
                Height = a.SecondaryFile.Height
              } : null,
              TertiaryFile = a.TertiaryFile != null ? new FileDTO {
                Name = a.TertiaryFile.Name,
                Width = a.TertiaryFile.Width,
                Height = a.TertiaryFile.Height
              } : null,
            }
          })
        .ToList();

      return res;
    }
  }
}
