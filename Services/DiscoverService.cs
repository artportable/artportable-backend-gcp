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

    public List<ArtistDTO> GetArtists(string myUsername)
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
