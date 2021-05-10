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

    public DiscoverService(APContext apContext, IMapper mapper)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    public List<ArtworkDTO> GetArtworks(int page, int pageSize, string myUsername)
    {
      return _context.Artworks
        .OrderByDescending(a => a.Published)
        .Skip(pageSize * (page-1))
        .Take(pageSize)
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
          Price = a.Price,
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

    public List<ArtistDTO> GetArtists(int page, int pageSize, string myUsername)
    {
      var users = _context.Users
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
        .Where(u => u.Artworks.Count() > 0)
        .Skip(pageSize * (page-1))
        .Take(pageSize)
        .Select(u => new ArtistDTO {
          Username = u.Username,
          ProfilePicture = u.File.Name,
          Location = u.UserProfile.Location,
          Artworks = u.Artworks
            .OrderBy(a => a.Likes.Count())
            .Take(15)
            .Select(a => new FileDTO {
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
          FollowedByMe = myUsername != null ?
            _context.Connections
              .Any(c => c.Followee.Username == u.Username && c.Follower.Username == myUsername) :
            false
        })
        .ToList();

      return artists;
    }
  }
}
