using Artportable.API.DTOs;
using Artportable.API.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Artportable.API.Enums;
using Artportable.API.Entities.Models;
using System.Linq.Expressions;
using NinjaNye.SearchExtensions;
using Artportable.API.Interfaces.Services;

namespace Artportable.API.Services
{
  public class SearchService : ISearchService
  {
    private APContext _context;
    private readonly IMapper _mapper;

    public SearchService(APContext apContext, IMapper mapper)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    public List<ArtworkDTO> SearchArtworks(int page, int pageSize, string myUsername, string q, List<string> tags, ProductEnum minimumProduct = ProductEnum.Portfolio)
    {
      IQueryable<Artwork> query = _context.Artworks;
      if (!string.IsNullOrWhiteSpace(q))
      {
        var terms = q.Split(' ');
        query = query.Search(
                  a => a.Title,
                  a => a.User.Username,
                  a => a.User.UserProfile.Name,
                  a => a.User.UserProfile.Surname)
                .Containing(terms)
                .ToRanked()
                .OrderByDescending(r => r.Hits)
                .Select(a => a.Item);
      }
      return query.Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
      .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
      .Skip(pageSize * (page - 1))
      .Take(pageSize)
      .Select(a => new ArtworkDTO
      {
        Id = a.PublicId,
        Owner = new OwnerDTO
        {
          Username = a.User.Username,
          ProfilePicture = a.User.File.Name,
          SocialId = a.User.SocialId,
          Name = a.User.UserProfile.Name,
          Surname = a.User.UserProfile.Surname,
          Location = a.User.UserProfile.Location
        },
        Title = a.Title,
        Name = a.User.UserProfile.Name,
        Surname = a.User.UserProfile.Surname,
        Description = a.Description,
        Published = a.Published,
        Price = a.Price,
        SoldOut = a.SoldOut,
        MultipleSizes = a.MultipleSizes,
        Width = a.Width,
        Height = a.Height,
        Depth = a.Depth,
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
        Tags = (a.Tags != null ? a.Tags.Select(t => t.Title).ToList() : new List<string>()),
        Likes = a.Likes.Count(),
        LikedByMe = !string.IsNullOrWhiteSpace(myUsername) ? a.Likes.Any(l => l.User.Username == myUsername) : false,
      }).ToList();
    }
    public List<ArtistDTO> SearchArtists(int page, int pageSize, string myUsername, string q, int minArtworks = 1, ProductEnum minimumProduct = ProductEnum.Portfolio)
    {
      IQueryable<User> query = _context.Users;
      if (!string.IsNullOrWhiteSpace(q))
      {
        var terms = q.Split(' ');
        query = query.Search(
          u => u.Username,
          u => u.UserProfile.Name,
          u => u.UserProfile.Surname)
        .Containing(terms)
        .ToRanked()
        .OrderByDescending(r => r.Hits)
        .Select(a => a.Item);
      }

      var artists = query.Include(u => u.UserProfile)
        .Include(u => u.File)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.PrimaryFile)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.Tags)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.Likes)
        .Where(u => u.Artworks.Count() >= minArtworks)
        .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
        .Skip(pageSize * (page - 1))
        .Take(pageSize)
        .Select(u => new ArtistDTO
        {
          Username = u.Username,
          ProfilePicture = u.File.Name,
          Location = u.UserProfile.Location,
          Name = u.UserProfile.Name,
          Surname = u.UserProfile.Surname,
          Artworks = u.Artworks
            .OrderBy(a => a.Likes.Count())
            .Take(15)
            .Select(a => new TinyArtworkDTO
            {
              Id = a.PublicId,
              Title = a.Title,
              PrimaryFile = new FileDTO
              {
                Name = a.PrimaryFile.Name,
                Width = a.PrimaryFile.Width,
                Height = a.PrimaryFile.Height
              }
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
            false,
          MonthlyArtist = u.MonthlyUser
        })
        .ToList();

      return artists;
    }
    public List<ArtistDTO> SearchMonthlyArtists(int page, int pageSize, string myUsername, string q)
    {
      IQueryable<User> users = _context.Users;
      if (!string.IsNullOrWhiteSpace(q))
      {
        var terms = q.Split(' ');
        users = users.Search(
          u => u.Username,
          u => u.UserProfile.Name,
          u => u.UserProfile.Surname)
        .Containing(terms)
        .ToRanked()
        .OrderByDescending(r => r.Hits)
        .Select(a => a.Item);
      }

      var artists = users.Include(u => u.UserProfile)
        .Include(u => u.File)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.PrimaryFile)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.Tags)
        .Include(u => u.Artworks)
        .ThenInclude(a => a.Likes)
        .Where(u => u.MonthlyUser)
        .Where(u => u.Artworks.Count() > 0)
        .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
        .Skip(pageSize * (page - 1))
        .Take(pageSize)
        .Select(u => new ArtistDTO
        {
          Username = u.Username,
          ProfilePicture = u.File.Name,
          Location = u.UserProfile.Location,
          Name = u.UserProfile.Name,
          Surname = u.UserProfile.Surname,
          Artworks = u.Artworks
            .OrderBy(a => a.Likes.Count())
            .Take(15)
            .Select(a => new TinyArtworkDTO
            {
              Id = a.PublicId,
              Title = a.Title,
              PrimaryFile = new FileDTO
              {
                Name = a.PrimaryFile.Name,
                Width = a.PrimaryFile.Width,
                Height = a.PrimaryFile.Height
              }
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
            false,
          MonthlyArtist = u.MonthlyUser
        })
        .ToList();

      return artists;
    }
  }
}

