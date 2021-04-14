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
          Owner = a.User.Username,
          Title = a.Title,
          Description = a.Description,
          Published = a.Published,
          PrimaryFile = a.PrimaryFile.Name,
          SecondaryFile = a.SecondaryFile != null ? a.SecondaryFile.Name : null,
          TertiaryFile = a.TertiaryFile != null ? a.TertiaryFile.Name : null,
          Tags = a.Tags != null ? a.Tags.Select(t => t.Title).ToList() : new List<string>(),
          Likes = a.Likes.Count(),
          LikedByMe = myUsername != null ? a.Likes.Any(l => l.User.Username == myUsername) : false
        })
        .ToList();
    }

    public ArtworkDTO Get(Guid id)
    {
      var artwork = _context.Artworks
        .Include(a => a.User)
        .Include(a => a.PrimaryFile)
        .Include(a => a.SecondaryFile)
        .Include(a => a.TertiaryFile)
        .Include(a => a.Likes)
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
          Owner = artwork.User.Username,
          Title = artwork.Title,
          Description = artwork.Description,
          Published = artwork.Published,
          PrimaryFile = artwork.PrimaryFile.Name,
          SecondaryFile = artwork.SecondaryFile != null ? artwork.SecondaryFile.Name : null,
          TertiaryFile = artwork.TertiaryFile != null ? artwork.TertiaryFile.Name : null,
          Tags = artwork.Tags != null ? artwork.Tags?.Select(t => t.Title).ToList() : new List<string>(),
          Likes = artwork.Likes.Count()
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

    public bool Like(Guid artworkId, Guid userId)
    {
      var aId = _context.Artworks.FirstOrDefault(a => a.PublicId == artworkId)?.Id;
      var uId = _context.Users.FirstOrDefault(u => u.PublicId == userId)?.Id;

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

    public void Unlike(Guid artworkId, Guid userId)
    {
      var record = _context.Likes
        .Include(l => l.Artwork)
        .Include(l => l.User)
        .Where(l => l.Artwork.PublicId == artworkId && l.User.PublicId == userId)
        .FirstOrDefault();

      if (record == null) {
        return;
      }

      _context.Likes.Remove(record);
      _context.SaveChanges();
    }
  }
}
