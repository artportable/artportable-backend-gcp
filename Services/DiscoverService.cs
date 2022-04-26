using Artportable.API.DTOs;
using Artportable.API.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Artportable.API.Enums;

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

    public List<ArtworkDTO> GetArtworks(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Bas)
     {
      return _context.Artworks
        .FromSqlInterpolated(
          $@"SELECT *, HASHBYTES('md5',cast(id+{seed} as varchar)) AS random FROM artworks
          ORDER BY random OFFSET 0 ROWS")
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
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
        })
        .ToList();
    }

        public List<ArtworkDTO> GetArtworksSold(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Bas)
     {
      return _context.Artworks
        .FromSqlInterpolated(
          $@"SELECT *, HASHBYTES('md5',cast(id+{seed} as varchar)) AS random FROM artworks
          ORDER BY random OFFSET 0 ROWS")
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .Where(x => x.SoldOut == true)
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
        })
        .ToList();
    }

        public List<ArtworkDTO> GetArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Bas)
     {
      return _context.Artworks
        .FromSqlInterpolated(
          $@"SELECT *, HASHBYTES('md5',cast(id+{seed} as varchar)) AS random FROM artworks
          ORDER BY random OFFSET 0 ROWS")
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .Where(x => x.SoldOut == false)
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
        })
        .ToList();
    }

    public List<ArtistDTO> GetArtists(int page, int pageSize, string myUsername, int seed, int minArtworks = 1, ProductEnum minimumProduct = ProductEnum.Portfolio)
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
        .Where(u => u.Artworks.Count() > minArtworks)
        .Where(u => u.Subscription.ProductId >= (int)minimumProduct)
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
            .Take(6)
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
    public List<ArtistDTO> GetMonthlyArtists(int page, int pageSize, string myUsername, int seed)
    {
      var random = new Random(seed);
      var users = _context.Users
      .Select( u => new 
      {
        Artworks = u.Artworks
          .OrderBy(a => a.Likes.Count())
          .Take(6)
          .Select(a => new 
          {
            PublicId = a.PublicId,
            Title = a.Title,
            PrimaryFile = new 
            {
              Name = a.PrimaryFile.Name,
              Width = a.PrimaryFile.Width,
              Height = a.PrimaryFile.Height
            },
            Tags = a.Tags
            .Select(
              t => new 
              {
                Title = t.Title
              }).ToList()  
          }).ToList(),
        Subscription = new 
        {
          ProductId = u.Subscription.ProductId
        },
        Username = u.Username,
        File = new 
        {
          Name = u.File.Name
        },
        UserProfile = new 
        {
          Location = u.UserProfile.Location,
          Name = u.UserProfile.Name,
          Surname = u.UserProfile.Surname,
        },
        MonthlyUser = u.MonthlyUser,
        Random = random.Next().ToString()
      })
      .Where(u => u.Username != myUsername)
      .Where(u => u.MonthlyUser)
      .Where(u => u.Artworks.Count() > 0)
      .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
      .AsEnumerable()
      .OrderBy(u => u.Random)
      .Skip(pageSize * (page - 1))
      .Take(pageSize);

      var artists = users
        .Select(u => new ArtistDTO
        {
          Username = u.Username,
          ProfilePicture = u.File.Name,
          Location = u.UserProfile.Location,
          Name = u.UserProfile.Name,
          Surname = u.UserProfile.Surname,
          Artworks = u.Artworks
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

    public List<ArtworkDTO> GetTopArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
    {
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .OrderByDescending(a => a.Likes.Count)
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
        })
        .ToList();
    }

        public List<ArtworkDTO> GetTopArtworksSold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
    {
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .Where(x => x.SoldOut == true)
        .OrderByDescending(a => a.Likes.Count)
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
        })
        .ToList();
    }

        public List<ArtworkDTO> GetTopArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
    {
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .Where(x => x.SoldOut == false)
        .OrderByDescending(a => a.Likes.Count)
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
        })
        .ToList();
    }

    public List<ArtistDTO> GetTopArtists(int page, int pageSize, string myUsername, int minArtworks = 1, ProductEnum minimumProduct = ProductEnum.Portfolio)
    {
      var users = _context.Users
        .Select( u => new 
        { 
          Artworks = u.Artworks
            .OrderBy(a => a.Likes.Count())
            .Take(6)
            .Select(a => new 
            {
              PublicId = a.PublicId,
              Title = a.Title,
              PrimaryFile = new 
              {
                Name = a.PrimaryFile.Name,
                Width = a.PrimaryFile.Width,
                Height = a.PrimaryFile.Height
              },
              Tags = a.Tags
              .Select(
                t => new 
                {
                  Title = t.Title
                }).ToList()  
            }).ToList(),
          Subscription = new 
          {
            ProductId = u.Subscription.ProductId
          },
          Username = u.Username,
          File = new 
          {
            Name = u.File.Name
          },
          UserProfile = new 
          {
            Location = u.UserProfile.Location,
            Name = u.UserProfile.Name,
            Surname = u.UserProfile.Surname,
          },
          MonthlyUser = u.MonthlyUser,
          FolloweeRef = u.FolloweeRef.Count
        })
        .Where(u => u.Username != myUsername)
        .Where(u => u.Artworks.Count() > minArtworks)
        .Where(u => u.Subscription.ProductId >= (int)minimumProduct)
        .OrderByDescending(u => u.FolloweeRef)
        .Skip(pageSize * (page - 1))
        .Take(pageSize)
        .ToList();

      var artists = users
        .Select(u => new ArtistDTO
        {
          Username = u.Username,
          ProfilePicture = u.File.Name,
          Location = u.UserProfile.Location,
          Name = u.UserProfile.Name,
          Surname = u.UserProfile.Surname,
          Artworks = u.Artworks
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

    public List<ArtworkDTO> GetTrendingArtworks (int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .OrderByDescending(a => a.Likes.Select(
              l => new {
                Date = l.Date
            })
            .Where(l => l.Date > likesSince)
            .Count())
        .ThenByDescending(a => a.Likes.Count())
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
        })
        .ToList();
    }

    public List<ArtworkDTO> GetLatestArtworks (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .OrderByDescending(a => a.Published)
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
        })
        .ToList();
    }

    public List<ArtworkDTO> GetLatestArtworksSold (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .Where(x => x.SoldOut == true)
        .OrderByDescending(a => a.Published)
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
        })
        .ToList();
    }

    public List<ArtworkDTO> GetLatestArtworksUnsold (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .Where(x => x.SoldOut == false)
        .OrderByDescending(a => a.Published)
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
        })
        .ToList();
    }

    public List<ArtworkDTO> GetLikedByMeArtworks (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.Likes.Any(x => x.User.Subscription.ProductId == 10))
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
        })
        .ToList();
    }

    public List<ArtworkDTO> GetLikedByMeArtworksSold (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.Likes.Any(l => l.User.Username == myUsername))
        .Where(x => x.SoldOut == true)
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
        })
        .ToList();
    }

    public List<ArtworkDTO> GetLikedByMeArtworksUnsold (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.Likes.Any(l => l.User.Username == myUsername))
        .Where(x => x.SoldOut == false)
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
        })
        .ToList();
    }

    public List<ArtworkDTO> GetTrendingArtworksSold (int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .Where(x => x.SoldOut == true)
        .OrderByDescending(a => a.Likes.Select(
              l => new {
                Date = l.Date
            })
            .Where(l => l.Date > likesSince)
            .Count())
        .ThenByDescending(a => a.Likes.Count())
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
        })
        .ToList();
    }

    public List<ArtworkDTO> GetTrendingArtworksUnsold (int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
        .Where(x => x.SoldOut == false)
        .OrderByDescending(a => a.Likes.Select(
              l => new {
                Date = l.Date
            })
            .Where(l => l.Date > likesSince)
            .Count())
        .ThenByDescending(a => a.Likes.Count())
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
        })
        .ToList();
    }

    
    public List<ArtworkDTO> GetCuratedArtworks (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.Likes.Any(x => x.User.Subscription.ProductId == 10))
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
        })
        .ToList();
    }


    public List<ArtworkDTO> GetCuratedArtworksSold (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.Likes.Any(x => x.User.Subscription.ProductId == 10))
        .Where(x => x.SoldOut == true)
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
        })
        .ToList();
    }


    public List<ArtworkDTO> GetCuratedArtworksUnsold (int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio){
      return _context.Artworks
        .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
        .Where(a => a.Likes.Any(x => x.User.Subscription.ProductId == 10))
        .Where(x => x.SoldOut == false)
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
        })
        .ToList();
    }




  }
}
