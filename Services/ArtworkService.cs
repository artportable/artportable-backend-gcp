using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
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

    public List<ArtworkDTO> Get(string owner, string myUsername)
    {
      return _context.Artworks
        .Where(a => owner != null ? a.User.Username == owner : true)
        .OrderByDescending(a => a.Published)
        .Select(a =>
        new ArtworkDTO
        {
          Id = a.PublicId,
          Owner = new OwnerDTO {
            Username = a.User.Username,
            ProfilePicture = a.User.File.Name,
            Location = a.User.UserProfile.Location
          },
          Title = a.Title,
          Description = a.Description,
          Published = a.Published,
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
          Tags = a.Tags != null ? a.Tags.Select(t => t.Title).ToList() : new List<string>(),
          Likes = a.Likes.Count(),
          LikedByMe = myUsername != null ? a.Likes.Any(l => l.User.Username == myUsername) : false
        })
        .ToList();
    }

    public ArtworkDTO Get(Guid id, string myUsername)
    {
      var artwork = _context.Artworks
        .Include(a => a.User)
        .ThenInclude(u => u.File)
        .Include(a => a.User.UserProfile)
        .Include(a => a.PrimaryFile)
        .Include(a => a.SecondaryFile)
        .Include(a => a.TertiaryFile)
        .Include(a => a.Likes)
        .ThenInclude(l => l.User)
        .Include(a => a.Tags)
        .Where(a => a.PublicId == id)
        .SingleOrDefault();

      if (artwork == null)
      {
        return null;
      }

      return new ArtworkDTO
        {
          Id = artwork.PublicId,
          Owner = new OwnerDTO {
            Username = artwork.User.Username,
            ProfilePicture = artwork.User.File.Name,
            Location = artwork.User.UserProfile.Location
          },
          Title = artwork.Title,
          Description = artwork.Description,
          Published = artwork.Published,
          PrimaryFile = new FileDTO {
            Name = artwork.PrimaryFile.Name,
            Width = artwork.PrimaryFile.Width,
            Height = artwork.PrimaryFile.Height
          },
          SecondaryFile = artwork.SecondaryFile != null ? new FileDTO {
            Name = artwork.SecondaryFile.Name,
            Width = artwork.SecondaryFile.Width,
            Height = artwork.SecondaryFile.Height
          } : null,
          TertiaryFile = artwork.TertiaryFile != null ? new FileDTO {
            Name = artwork.TertiaryFile.Name,
            Width = artwork.TertiaryFile.Width,
            Height = artwork.TertiaryFile.Height
          } : null,
          Tags = artwork.Tags != null ? artwork.Tags?.Select(t => t.Title).ToList() : new List<string>(),
          Likes = artwork.Likes.Count(),
          LikedByMe = myUsername != null ? artwork.Likes.Any(l => l.User.Username == myUsername) : false
        };
    }

    public List<TagDTO> GetTags(Guid id)
    {
      var artwork = _context.Artworks
        .Include(a => a.Tags)
        .FirstOrDefault(a => a.PublicId == id);

      if (artwork == null)
      {
        return null;
      }

      var tags = artwork.Tags
        .Select(t => new TagDTO { Tag = t.Title })
        .ToList();

      return tags;
    }

    public bool Like(Guid artworkId, string myUsername)
    {
      var aId = _context.Artworks.FirstOrDefault(a => a.PublicId == artworkId)?.Id;
      var uId = _context.Users.FirstOrDefault(u => u.Username == myUsername)?.Id;

      if (aId == null || uId == null) {
        return false;
      }

      var exists = _context.Likes
        .Count(l => l.ArtworkId == aId && l.UserId == uId);

      if (exists > 1)
      {
        Console.WriteLine("WARN: There are more than one ({0}) copies of likes for user {1} on artwork {2}", exists, uId, aId);
        return true;
      }
      else if (exists > 0)
      {
        return true;
      }

      _context.Likes.Add(
        new Like
        {
          ArtworkId = (int) aId,
          UserId = (int) uId
        }
      );
      _context.SaveChanges();

      return true;
    }

    public void Unlike(Guid artworkId, string myUsername)
    {
      var record = _context.Likes
        .Include(l => l.Artwork)
        .Include(l => l.User)
        .Where(l => l.Artwork.PublicId == artworkId && l.User.Username == myUsername)
        .FirstOrDefault();

      if (record == null) {
        return;
      }

      _context.Likes.Remove(record);
      _context.SaveChanges();
    }
  }
}
