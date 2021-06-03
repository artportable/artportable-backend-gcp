using Artportable.API.DTOs;
using Artportable.API.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Artportable.API.Services
{
  public class DiscoverService : IDiscoverService
  {
    private APContext _context;
    private readonly IMapper _mapper;
    private readonly Random _random = new Random();

    public DiscoverService(APContext apContext, IMapper mapper)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    public List<ArtworkDTO> GetArtworks(int page, int pageSize, List<string> tags, string myUsername, int seed)
    {
      return _context.Artworks
        .FromSqlInterpolated(
          $@"SELECT *, HASHBYTES('md5',cast(id+{seed} as varchar)) AS random FROM artworks
          ORDER BY random OFFSET 0 ROWS")
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Skip(pageSize * (page - 1))
        .Take(pageSize)
        .Select(a =>
        new ArtworkDTO
        {
          Id = a.PublicId,
          Owner = new OwnerDTO
          {
            Username = a.User.Username,
            ProfilePicture = a.User.File.Name,
            Location = a.User.UserProfile.Location
          },
          Title = a.Title,
          Description = a.Description,
          Published = a.Published,
          Price = a.Price,
          PrimaryFile = new FileDTO
          {
            Name = a.PrimaryFile.Name,
            Width = a.PrimaryFile.Width,
            Height = a.PrimaryFile.Height
          },
          SecondaryFile = a.SecondaryFile != null ? new FileDTO
          {
            Name = a.SecondaryFile.Name,
            Width = a.SecondaryFile.Width,
            Height = a.SecondaryFile.Height
          } : null,
          TertiaryFile = a.TertiaryFile != null ? new FileDTO
          {
            Name = a.TertiaryFile.Name,
            Width = a.TertiaryFile.Width,
            Height = a.TertiaryFile.Height
          } : null,
          Tags = a.Tags != null ? a.Tags.Select(t => t.Title).ToList() : new List<string>(),
          Likes = a.Likes.Count() + _random.Next(25, 200),
          LikedByMe = !string.IsNullOrWhiteSpace(myUsername) ? a.Likes.Any(l => l.User.Username == myUsername) : false
        })
        .ToList();
    }

    public List<ArtistDTO> GetArtists(int page, int pageSize, string q, string myUsername, int seed)
    {
      var users = _context.Users
        .FromSqlInterpolated(
          $@"SELECT *, HASHBYTES('md5',cast(id+{seed} as varchar)) AS random FROM users
          ORDER BY random OFFSET 0 ROWS")
        .Include(u => u.UserProfile)
        .Include(u => u.File)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.PrimaryFile)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.Tags)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.Likes);

      var artists = users
        .Where(u => u.Username != myUsername)
        .Where(u => u.Artworks.Count() > 5)
        .Where(u => q != null ? u.Username.Contains(q) : true)
        .Skip(pageSize * (page - 1))
        .Take(pageSize)
        .Select(u => new ArtistDTO
        {
          Username = u.Username,
          ProfilePicture = u.File.Name,
          Location = u.UserProfile.Location,
          Images = u.Artworks
            .OrderBy(a => a.Likes.Count())
            .Take(15)
            .Select(a => new FileDTO
            {
              Name = a.PrimaryFile.Name,
              Width = a.PrimaryFile.Width,
              Height = a.PrimaryFile.Height,
            })
            .ToList(),
          Tags = u.Artworks
            .SelectMany(a => a.Tags
              .Select(t => t.Title)
            )
            .Take(5)
            .ToList(),
          FollowedByMe = !string.IsNullOrWhiteSpace(myUsername) ?
            _context.Connections
              .Any(c => c.Followee.Username == u.Username && c.Follower.Username == myUsername) :
            false
        })
        .ToList();

      return artists;
    }
  }
}
