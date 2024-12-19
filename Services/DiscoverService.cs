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
    var randomSeed = seed.ToString();

    var query = _context.Artworks
        .FromSqlInterpolated(
            $@"SELECT *, HASHBYTES('md5', cast(id + {randomSeed} as varchar)) AS random FROM artworks
            ORDER BY random OFFSET 0 ROWS")
        .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct);
    
    if (tags != null && tags.Count != 0)
    {
    foreach (var tag in tags)
    {
        query = query.Where(a => a.Tags.Any(t => tag.Contains(t.Title)));
    };
    }
    var result = query
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                  Currency = a.Currency,
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

            return result;
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                  Currency = a.Currency,
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                  Currency = a.Currency,
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
                  SocialId = u.SocialId,
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
        public List<ArtistDTO> GetMonthlyArtists(int page, int pageSize, string myUsername, int seed, int minArtworks = 1, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            var random = new Random(seed);
            var users = _context.Users
            .Select(u => new
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
                SocialId = u.SocialId,
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

            var userss = users
    
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
                  SocialId = u.SocialId,
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

            return userss;
        }

        public List<ArtworkDTO> GetTopArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {


            DateTime sixMonthsAgo = DateTime.Now.AddMonths(-6);
            return _context.Artworks
              .Where(a => a.Published >= sixMonthsAgo) 
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
                  Username = a.User.Username,
                  Surname = a.User.UserProfile.Surname,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                  Currency = a.Currency,
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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
              .Select(u => new
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
                  SocialId = u.SocialId,
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

            var artistss = users
              .Select(u => new ArtistDTO
              {
                  Username = u.Username,
                  ProfilePicture = u.File.Name,
                  Location = u.UserProfile.Location,
                  Name = u.UserProfile.Name,
                  Surname = u.UserProfile.Surname,
                  SocialId = u.SocialId,
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

            return artistss;
        }


        public List<ArtworkDTO> GetLatestArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
              .Where(a => !a.Tags.Any(t => t.Title == "AI" || t.Title == "Digital"))
              .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
              .Where(a => a.User.Subscription.ProductId >= (int)ProductEnum.Portfolio)
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                  Currency = a.Currency,
                  SoldOut = a.SoldOut,
                  MultipleSizes = a.MultipleSizes,
                  Width = a.Width,
                  Height = a.Height,
                  Depth = a.Depth,
                 Country = a.User.UserProfile.Country,
                  State = a.User.UserProfile.State,
                  City = a.User.UserProfile.City,
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


            public List<ArtworkDTO> GetDigitalArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
              .Where(a => a.Tags.Any(t => t.Title == "AI" || t.Title == "Digital")) 
              .Where(a => a.User.Subscription.ProductId >= (int)ProductEnum.Portfolio)
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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

        public List<ArtworkDTO> GetLatestArtworksSold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
              .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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

        public List<ArtworkDTO> GetLatestArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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

         public List<ArtworkDTO> GetLikedByMeArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
                .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
                .Where(a => a.Likes.Any(l => l.User.Username == myUsername))
                .Join(_context.Likes, a => a.Id, l => l.ArtworkId, (a, l) => new { Artwork = a, Like = l })
                .Where(joined => joined.Like.User.Username == myUsername)
                .OrderByDescending(joined => joined.Like.Date)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Select(joined => new ArtworkDTO
                {
                    Id = joined.Artwork.PublicId,
                    Owner = new OwnerDTO
                    {
                        Username = joined.Artwork.User.Username,
                        ProfilePicture = joined.Artwork.User.File.Name,
                        SocialId = joined.Artwork.User.SocialId,
                        Name = joined.Artwork.User.UserProfile.Name,
                        Surname = joined.Artwork.User.UserProfile.Surname,
                        Location = joined.Artwork.User.UserProfile.Location
                    },
                    Title = joined.Artwork.Title,
                    Name = joined.Artwork.User.UserProfile.Name,
                    Surname = joined.Artwork.User.UserProfile.Surname,
                    Username = joined.Artwork.User.Username,
                    Description = joined.Artwork.Description,
                    Published = joined.Artwork.Published,
                    Price = joined.Artwork.Price,
                    Currency = joined.Artwork.Currency,
                    SoldOut = joined.Artwork.SoldOut,
                    MultipleSizes = joined.Artwork.MultipleSizes,
                    Width = joined.Artwork.Width,
                    Height = joined.Artwork.Height,
                    Depth = joined.Artwork.Depth,
                    PrimaryFile = new FileDTO
                    {
                        Name = joined.Artwork.PrimaryFile.Name,
                        Width = joined.Artwork.PrimaryFile.Width,
                        Height = joined.Artwork.PrimaryFile.Height
                    },
                    SecondaryFile = joined.Artwork.SecondaryFile != null ? new FileDTO
                    {
                        Name = joined.Artwork.SecondaryFile.Name,
                        Width = joined.Artwork.SecondaryFile.Width,
                        Height = joined.Artwork.SecondaryFile.Height
                    } : null,
                    TertiaryFile = joined.Artwork.TertiaryFile != null ? new FileDTO
                    {
                        Name = joined.Artwork.TertiaryFile.Name,
                        Width = joined.Artwork.TertiaryFile.Width,
                        Height = joined.Artwork.TertiaryFile.Height
                    } : null,
                    Tags = (joined.Artwork.Tags != null ? joined.Artwork.Tags.Select(t => t.Title).ToList() : new List<string>()),
                    Likes = joined.Artwork.Likes.Count(),
                    LikedByMe = !string.IsNullOrWhiteSpace(myUsername) ? joined.Artwork.Likes.Any(l => l.User.Username == myUsername) : false,
                })
                .ToList();
        }

        public List<ArtworkDTO> GetLikedArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio) {
            return _context.Artworks
                .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
                .Join(_context.Likes, a => a.Id, l => l.ArtworkId, (a, l) => new { Artwork = a, Like = l })
                .Where(joined => joined.Like.User.Username == myUsername && joined.Artwork.User.Username != myUsername)
                .OrderByDescending(joined => joined.Like.Date)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Select(joined => new ArtworkDTO
                {
                    Id = joined.Artwork.PublicId,
                    Owner = new OwnerDTO
                    {
                        Username = joined.Artwork.User.Username,
                        ProfilePicture = joined.Artwork.User.File.Name,
                        SocialId = joined.Artwork.User.SocialId,
                        Name = joined.Artwork.User.UserProfile.Name,
                        Surname = joined.Artwork.User.UserProfile.Surname,
                        Location = joined.Artwork.User.UserProfile.Location
                    },
                    Title = joined.Artwork.Title,
                    Name = joined.Artwork.User.UserProfile.Name,
                    Surname = joined.Artwork.User.UserProfile.Surname,
                    Username = joined.Artwork.User.Username,
                    Description = joined.Artwork.Description,
                    Published = joined.Artwork.Published,
                    Price = joined.Artwork.Price,
                    Currency = joined.Artwork.Currency,
                    SoldOut = joined.Artwork.SoldOut,
                    MultipleSizes = joined.Artwork.MultipleSizes,
                    Width = joined.Artwork.Width,
                    Height = joined.Artwork.Height,
                    Depth = joined.Artwork.Depth,
                    PrimaryFile = new FileDTO
                    {
                        Name = joined.Artwork.PrimaryFile.Name,
                        Width = joined.Artwork.PrimaryFile.Width,
                        Height = joined.Artwork.PrimaryFile.Height
                    },
                    SecondaryFile = joined.Artwork.SecondaryFile != null ? new FileDTO
                    {
                        Name = joined.Artwork.SecondaryFile.Name,
                        Width = joined.Artwork.SecondaryFile.Width,
                        Height = joined.Artwork.SecondaryFile.Height
                    } : null,
                    TertiaryFile = joined.Artwork.TertiaryFile != null ? new FileDTO
                    {
                        Name = joined.Artwork.TertiaryFile.Name,
                        Width = joined.Artwork.TertiaryFile.Width,
                        Height = joined.Artwork.TertiaryFile.Height
                    } : null,
                    Tags = (joined.Artwork.Tags != null ? joined.Artwork.Tags.Select(t => t.Title).ToList() : new List<string>()),
                    Likes = joined.Artwork.Likes.Count(),
                    LikedByMe = !string.IsNullOrWhiteSpace(myUsername) ? joined.Artwork.Likes.Any(l => l.User.Username == myUsername) : false,
                })
                .ToList();
        }

        public List<ArtworkDTO> GetLikedByMeArtworksSold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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

        public List<ArtworkDTO> GetLikedByMeArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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

        public List<ArtworkDTO> GetTrendingArtworks(int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, string orientation, string sizeFilter = null, string priceFilter = null,ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
                var query = _context.Artworks
                    .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct);

                if (tags != null && tags.Count != 0)
                {
                    foreach (var tag in tags)
                    {
                        query = query.Where(a => a.Tags.Any(t => t.Title == tag));
                    }
                }

                if (!string.IsNullOrWhiteSpace(orientation))
                {
                       if (orientation.Equals("Vertical", StringComparison.OrdinalIgnoreCase))
                    {
                        query = query.Where(a => a.Height > a.Width);
                    }
                    else if (orientation.Equals("Horizontal", StringComparison.OrdinalIgnoreCase))
                    {
                        query = query.Where(a => a.Width > a.Height);
                    }
                }

                if (!string.IsNullOrEmpty(sizeFilter))
                {
                    if (sizeFilter == "30")
                    {
                        query = query.Where(a => a.Height <= 30 && a.Width <= 30);
                    }
                    else if (sizeFilter == "60")
                    {
                        query = query.Where(a => a.Height <= 60 && a.Width <= 60);
                    }
                    else if (sizeFilter == "100")
                    {
                        query = query.Where(a => a.Height <= 100 && a.Width <= 100);
                    }
                    else if (sizeFilter == "101")
                    {
                        query = query.Where(a => a.Height > 100 || a.Width > 100);
                    }
                }

                if (!string.IsNullOrEmpty(priceFilter))
                
                {
                    decimal priceLimit;
                    if (decimal.TryParse(priceFilter, out priceLimit))
                    {
                        if (priceLimit == 5001)
                        {
                            query = query.Where(a => a.Price > priceLimit && a.SoldOut != true && a.Price != 0);
                        }
                        else
                        {
                            query = query.Where(a => a.Price <= priceLimit && a.SoldOut != true && a.Price != 0);
                        }
                    }
                }


                var artworks = query
                    .OrderByDescending(a => a.Likes.Select(
                            l => new
                            {
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
                      Location = a.User.UserProfile.Location,          
                      
                  },
                  Title = a.Title,
                  Name = a.User.UserProfile.Name,
                  Surname = a.User.UserProfile.Surname,
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                  Currency = a.Currency,
                  SoldOut = a.SoldOut,
                  MultipleSizes = a.MultipleSizes,
                  Width = a.Width,
                  Height = a.Height,
                  Depth = a.Depth,
                  Country = a.User.UserProfile.Country,
                  State = a.User.UserProfile.State,
                  City = a.User.UserProfile.City,
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
               return artworks;
        }

        public List<ArtworkDTO> GetTrendingArtworksSold(int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
              .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
              .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
              .Where(x => x.SoldOut == true)
              .OrderByDescending(a => a.Likes.Select(
                    l => new
                    {
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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

        public List<ArtworkDTO> GetTrendingArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
              .Where(a => tags.Count != 0 ? a.Tags.Any(t => tags.Contains(t.Title)) : true)
              .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
              .Where(x => x.SoldOut == false)
              .OrderByDescending(a => a.Likes.Select(
                    l => new
                    {
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                  Currency = a.Currency,
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


        public List<ArtworkDTO> GetCuratedArtworks(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
             var sinceDate = DateTime.UtcNow.AddDays(-182); 

                var randomArtworks = _context.Artworks
                    .FromSqlRaw(
                        $@"SELECT *, HASHBYTES('md5',cast(id+{seed} as varchar)) AS random FROM artworks
                        ORDER BY random OFFSET 0 ROWS");

                return randomArtworks
                    .Where(a => a.Published >= sinceDate) // Filter by artworks published in the last 2 weeks
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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


        public List<ArtworkDTO> GetCuratedArtworksSold(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
              .FromSqlInterpolated(
                $@"SELECT *, HASHBYTES('md5',cast(id+{seed} as varchar)) AS random FROM artworks
                ORDER BY random OFFSET 0 ROWS")
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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


        public List<ArtworkDTO> GetCuratedArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
              .FromSqlInterpolated(
                $@"SELECT *, HASHBYTES('md5',cast(id+{seed} as varchar)) AS random FROM artworks
                ORDER BY random OFFSET 0 ROWS")
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
                  Username = a.User.Username,
                  Description = a.Description,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
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

        public List<ArtworkDTO> GetPromotedArtworks(int page, int pageSize, int seed, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {

        
            return _context.Artworks
              .Where(a => a.Promoted == true)
              .OrderByDescending(a => a.PromotedAt) 
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
                  Username = a.User.Username,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
                  SoldOut = a.SoldOut,
                  MultipleSizes = a.MultipleSizes,
                  Width = a.Width,
                  Height = a.Height,
                  Depth = a.Depth,
                  Promoted = a.Promoted,
                  PromotedAt = a.PromotedAt,
                  IsBoosted = a.IsBoosted,
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
            public List<ArtworkDTO> GetBoostedArtworks(int page, int pageSize, int seed, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {

            return _context.Artworks
              .Where(a => a.IsBoosted == true)
              .OrderByDescending(a => a.BoostedAt) 
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
                  Username = a.User.Username,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
                  SoldOut = a.SoldOut,
                  MultipleSizes = a.MultipleSizes,
                  Width = a.Width,
                  Height = a.Height,
                  Depth = a.Depth,
                  Promoted = a.Promoted,
                  PromotedAt = a.PromotedAt,
                  IsBoosted = a.IsBoosted,
                  BoostedAt = a.BoostedAt,
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

             public List<ArtworkDTO> GetAafArtworks(int page, int pageSize, int seed, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {
            return _context.Artworks
              .Where(a => a.isAaf == true)
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
                  Username = a.User.Username,
                  Published = a.Published,
                  Price = a.Price,
                   Currency = a.Currency,
                  SoldOut = a.SoldOut,
                  MultipleSizes = a.MultipleSizes,
                  Width = a.Width,
                  Height = a.Height,
                  Depth = a.Depth,
                  Promoted = a.Promoted,
                  PromotedAt = a.PromotedAt,
                  isAaf = a.isAaf,
                  IsBoosted = a.IsBoosted,
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

        public List<StoryDTO> GetBoostedStories(int page, int pageSize, int seed, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio)
        {

            return _context.Stories
              .Where(a => a.IsBoosted == true)
              .OrderByDescending(a => a.BoostedAt) 
              .Skip(pageSize * (page - 1))
              .Take(pageSize)
              .Select(a =>
              new StoryDTO
              {
                  Id = a.PublicId,
                  Title = a.Title,
                  Description =a.Description,
                  Name = a.User.UserProfile.Name,
                  Surname = a.User.UserProfile.Surname,
                  Username = a.User.Username,
                  Published = a.Published,
                  Exhibition = a.Exhibition,
                  IsBoosted = a.IsBoosted,
                  BoostedAt = a.BoostedAt,
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
                  } : null 
              })
              .ToList();
            
        }



            public List<ArtworkDTO> GetFilteredArtworks(
                int page, 
                int pageSize, 
                List<string> tags, 
                string myUsername, 
                DateTime likesSince, 
                string orientation, 
                string sizeFilter = null, 
                string priceFilter = null, 
                string stateFilter = null,  
                ProductEnum minimumProduct = ProductEnum.Portfolio)
            {
                var query = _context.Artworks
                    .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct);

                // Filter by tags
                if (tags != null && tags.Count != 0)
                {
                    foreach (var tag in tags)
                    {
                        query = query.Where(a => a.Tags.Any(t => t.Title == tag));
                    }
                }

                // Filter by orientation
                if (!string.IsNullOrWhiteSpace(orientation))
                {
                    if (orientation.Equals("Vertical", StringComparison.OrdinalIgnoreCase))
                    {
                        query = query.Where(a => a.Height > a.Width);
                    }
                    else if (orientation.Equals("Horizontal", StringComparison.OrdinalIgnoreCase))
                    {
                        query = query.Where(a => a.Width > a.Height);
                    }
                }

                // Filter by size
                if (!string.IsNullOrEmpty(sizeFilter))
                {
                    if (sizeFilter == "30")
                    {
                        query = query.Where(a => a.Height <= 30 && a.Width <= 30);
                    }
                    else if (sizeFilter == "60")
                    {
                        query = query.Where(a => a.Height <= 60 && a.Width <= 60);
                    }
                    else if (sizeFilter == "100")
                    {
                        query = query.Where(a => a.Height <= 100 && a.Width <= 100);
                    }
                    else if (sizeFilter == "101")
                    {
                        query = query.Where(a => a.Height > 100 || a.Width > 100);
                    }
                }

                // Filter by price
                if (!string.IsNullOrEmpty(priceFilter))
                {
                    decimal priceLimit;
                    if (decimal.TryParse(priceFilter, out priceLimit))
                    {
                        if (priceLimit == 5001)
                        {
                            query = query.Where(a => a.Price > priceLimit && a.SoldOut != true && a.Price != 0);
                        }
                        else
                        {
                            query = query.Where(a => a.Price <= priceLimit && a.SoldOut != true && a.Price != 0);
                        }
                    }
                }


                if (!string.IsNullOrWhiteSpace(stateFilter))
                {
                    query = query.Where(a => a.User.UserProfile.State.Equals(stateFilter));
                }

                // Get the final list of artworks
                var artworks = query
                    .OrderByDescending(a => a.Likes
                        .Where(l => l.Date > likesSince)
                        .Count())
                    .ThenByDescending(a => a.Likes.Count())
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
                        Username = a.User.Username,
                        Description = a.Description,
                        Published = a.Published,
                        Price = a.Price,
                        Currency = a.Currency,
                        SoldOut = a.SoldOut,
                        MultipleSizes = a.MultipleSizes,
                        Width = a.Width,
                        Height = a.Height,
                        Depth = a.Depth,
                        Country = a.User.UserProfile.Country,
                        State = a.User.UserProfile.State,
                        City = a.User.UserProfile.City,
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

                return artworks;
            }

        
    }
}
