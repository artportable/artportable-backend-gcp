using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
using Artportable.API.Migrations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Services
{
  public class ArtworkService : IArtworkService
  {
    private APContext _context;
    private readonly IMapper _mapper;

    public ArtworkService(APContext apContext, IMapper mapper)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    public List<ArtworkDTO> Get(string owner, string myUsername)
    {
      var ownerProductId = _context.Users
        .Include(u => u.Subscription)
        .SingleOrDefault(u => u.Username == owner)?.Subscription?.ProductId;
      if (ownerProductId == (int)ProductEnum.Bas)
      {
          return new List<ArtworkDTO>();
      }
      var artworksQuery = _context.Artworks
        .Where(a => owner != null ? a.User.Username == owner : true);
      var orderedArtworks = artworksQuery
        .OrderByDescending(a => a.OrderIndex.HasValue)  
        .ThenBy(a => a.OrderIndex)
        .ThenByDescending(a => a.Published)
        .Select(a =>
        new ArtworkDTO
        {
          Id = a.PublicId,
          Owner = new OwnerDTO
          {
            Username = a.User.Username,
            ProfilePicture = a.User.File.Name,
            Name = a.User.UserProfile.Name,
            Surname = a.User.UserProfile.Surname,
            Location = a.User.UserProfile.Location,
            FollowedByMe = !string.IsNullOrWhiteSpace(myUsername) ?
            _context.Connections
              .Any(c => c.Followee.Username == owner && c.Follower.Username == myUsername) :
            false
          },
          Title = a.Title,
          Description = a.Description,
          Published = a.Published,
          Name = a.User.UserProfile.Name,
          Surname = a.User.UserProfile.Surname,
          Username = a.User.Username,
          Price = a.Price,
          Currency = a.Currency,
          SoldOut = a.SoldOut,
          MultipleSizes = a.MultipleSizes,
          Height = a.Height,
          Width = a.Width,
          Depth = a.Depth,
          OrderIndex = a.OrderIndex,
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
          Likes = a.Likes.Count(),
          LikedByMe = myUsername != null ? a.Likes.Any(l => l.User.Username == myUsername) : false
        })
        .ToList();

        return orderedArtworks;
    }

    public ArtworkDTO Get(Guid id, string myUsername)
    {
      var artwork = _context.Artworks
        .Where(a => a.PublicId == id)
        .Select(a => new {
          PublicId = a.PublicId,
          User = new {
            Username = a.User.Username,
            Name = a.User.UserProfile.Name,
            Surname = a.User.UserProfile.Surname,
            SocialId = a.User.SocialId,
            File = a.User.File != null ? new {
              Name = a.User.File.Name
            } : null,
            UserProfile = new {
              Location = a.User.UserProfile.Location
            },
            MonthlyUser = a.User.MonthlyUser
            
          },
          Title = a.Title,
          Description = a.Description,
          Published = a.Published,
          Price = a.Price,
          Currency = a.Currency,
          SoldOut = a.SoldOut,
          MultipleSizes = a.MultipleSizes,
          Height = a.Height,
          Width = a.Width,
          Depth = a.Depth,
          OrderIndex = a.OrderIndex,
          Promoted = a.Promoted,
          PromotedAt = a.PromotedAt,
          PromotionEndDate = a.PromotionEndDate,
          PrimaryFile = new {
            Name = a.PrimaryFile.Name,
            Width = a.PrimaryFile.Width,
            Height = a.PrimaryFile.Height, 
          },
          SecondaryFile = a.SecondaryFile != null ? new {
            Name = a.SecondaryFile.Name,
            Width = a.SecondaryFile.Width,
            Height = a.SecondaryFile.Height,
          } : null,
          TertiaryFile = a.TertiaryFile != null ? new {
            Name = a.TertiaryFile.Name,
            Width = a.TertiaryFile.Width,
            Height = a.TertiaryFile.Height,
          } : null,
          Tags = a.Tags,
          Likes = a.Likes.Select(
            l => new {
              User = new { 
                Username = l.User.Username
              } 
            }
          ).ToList()
        })
        .SingleOrDefault();

      if (artwork == null)
      {
        return null;
      }

      return new ArtworkDTO
      {
        Id = artwork.PublicId,
        Owner = new OwnerDTO
        {
          Username = artwork.User.Username,
          SocialId = artwork.User.SocialId,
          Name = artwork.User.Name,
          Surname = artwork.User.Surname,
          ProfilePicture = artwork.User.File?.Name,
          Location = artwork.User.UserProfile.Location,
          FollowedByMe = !string.IsNullOrWhiteSpace(myUsername) ?
            _context.Connections
              .Any(c => c.Followee.Username == artwork.User.Username && c.Follower.Username == myUsername) :
            false,
          MonthlyArtist = artwork.User.MonthlyUser
        },
        Title = artwork.Title,
        Description = artwork.Description,
        Published = artwork.Published,
        Price = artwork.Price,
        Currency = artwork.Currency,
        SoldOut = artwork.SoldOut,
        MultipleSizes = artwork.MultipleSizes,
        Height = artwork.Height,
        Width = artwork.Width,
        Depth = artwork.Depth,
        OrderIndex = artwork.OrderIndex,
        Promoted = artwork.Promoted,
        PromotedAt = artwork.PromotedAt,
        PromotionEndDate = artwork.PromotionEndDate,
        PrimaryFile = new FileDTO
        {
          Name = artwork.PrimaryFile.Name,
          Width = artwork.PrimaryFile.Width,
          Height = artwork.PrimaryFile.Height
        },
        SecondaryFile = artwork.SecondaryFile != null ? new FileDTO
        {
          Name = artwork.SecondaryFile.Name,
          Width = artwork.SecondaryFile.Width,
          Height = artwork.SecondaryFile.Height
        } : null,
        TertiaryFile = artwork.TertiaryFile != null ? new FileDTO
        {
          Name = artwork.TertiaryFile.Name,
          Width = artwork.TertiaryFile.Width,
          Height = artwork.TertiaryFile.Height
        } : null,
        Tags = artwork.Tags != null ? artwork.Tags?.Select(t => t.Title).ToList() : new List<string>(),
        Likes = artwork.Likes.Count(),
        LikedByMe = myUsername != null ? artwork.Likes.Any(l => l.User.Username == myUsername) : false
      };
    }
    public ArtworkDTO Create(ArtworkForCreationDTO dto, Guid mySocialId)
    {
      var user = _context.Users.FirstOrDefault(u => u.SocialId == mySocialId);

      if (user == null)
      {
        return null;
      }

      var artwork = new Artwork
      {
        PublicId = Guid.NewGuid(),
        User = user,
        Title = dto.Title,
        Description = dto.Description,
        Published = DateTime.Now,
        Price = dto.Price,
        Currency = dto.Currency,
        SoldOut = dto.SoldOut,
        MultipleSizes = dto.MultipleSizes,
        Height = dto.Height,
        Width = dto.Width,
        Depth = dto.Depth,
        PrimaryFile = _context.Files.Where(f => f.Name == dto.PrimaryFile).SingleOrDefault(),
        SecondaryFile = dto.SecondaryFile != null ? _context.Files.Where(f => f.Name == dto.SecondaryFile).SingleOrDefault() : null,
        TertiaryFile = dto.TertiaryFile != null ? _context.Files.Where(f => f.Name == dto.TertiaryFile).SingleOrDefault() : null,
        Tags = _context.Tags.Where(t => dto.Tags.Contains(t.Title)).ToList()
      };

      _context.Add(artwork);
      _context.SaveChanges();

      var artworkDto = _mapper.Map<ArtworkDTO>(artwork);

      return artworkDto;
    }

    public ArtworkDTO Update(ArtworkForUpdateDTO dto, Guid id, Guid mySocialId)
    {
      var artwork = _context.Artworks
        .Include(a => a.User)
        .Include(a => a.PrimaryFile)
        .Include(a => a.SecondaryFile)
        .Include(a => a.TertiaryFile)
        .Include(a => a.Tags)
        .Include(a => a.Likes)
        .FirstOrDefault(a => a.PublicId == id && a.User.SocialId == mySocialId);

      if (artwork == null)
      {
        return null;
      }
      artwork.Title = dto.Title;
      artwork.Description = dto.Description;
      artwork.Price = dto.Price;
      artwork.Currency = dto.Currency;
      artwork.SoldOut = dto.SoldOut;
      artwork.MultipleSizes = dto.MultipleSizes;
      artwork.Height = dto.Height;
      artwork.Width = dto.Width;
      artwork.Depth = dto.Depth;

      if (artwork.PrimaryFile.Name != dto.PrimaryFile)
      {
        var fileToRemove = artwork.PrimaryFile;
        _context.Files.Remove(fileToRemove);
        artwork.PrimaryFile = new File { Name = dto.PrimaryFile };
      }
      if (artwork.SecondaryFile?.Name != dto.PrimaryFile)
      {
        if (artwork?.SecondaryFile != null)
        {
          var fileToRemove = artwork?.SecondaryFile;
          _context.Files.Remove(fileToRemove);
        }
        if (dto.SecondaryFile != null)
        {
          artwork.SecondaryFile = new File { Name = dto.SecondaryFile };
        }
      }
      if (artwork.TertiaryFile?.Name != dto.TertiaryFile)
      {
        if (artwork?.TertiaryFile != null)
        {
          var fileToRemove = artwork?.TertiaryFile;
          _context.Files.Remove(fileToRemove);
        }
        if (dto.TertiaryFile != null)
        {
          artwork.TertiaryFile = new File { Name = dto.TertiaryFile };
        }
      }

      artwork.Tags.Clear();
      _context.Tags
        .Where(t => dto.Tags
        .Contains(t.Title))
        .ToList()
        .ForEach(tag => artwork.Tags.Add(tag));


      _context.Update(artwork);
      _context.SaveChanges();

      var artworkDto = _mapper.Map<ArtworkDTO>(artwork);
      artworkDto.Likes = artwork.Likes.Count();
      artworkDto.LikedByMe = mySocialId != null ? artwork.Likes.Any(l => l.User?.SocialId == mySocialId) : false;

      return artworkDto;
    }

    public ArtworkDTO Promote(ArtworkForPromotionDTO dto, Guid id)
  {
      var artwork = _context.Artworks.Include(a => a.User).FirstOrDefault(a => a.PublicId == id);

      if (artwork == null)
      {
          return null;
      }

      if (dto.Promoted)
      {
          artwork.Promoted = true;
          artwork.PromotedAt = DateTime.UtcNow;
          artwork.PromotionEndDate = DateTime.UtcNow.AddMonths(dto.PromotionDurationInMonths);
      }
      else
      {
          artwork.Promoted = false;
          artwork.PromotedAt = null;
          artwork.PromotionEndDate = null;
      }

      _context.Update(artwork);
      _context.SaveChanges();

      var artworkDto = _mapper.Map<ArtworkDTO>(artwork);
      return artworkDto;
  }




    public ArtworkDTO UpdateOrderIndex(Guid artworkId, int orderIndex)
    {
        var artwork = _context.Artworks.FirstOrDefault(a => a.PublicId == artworkId);

        if (artwork == null)
        {
            return null;
        }

        artwork.OrderIndex = orderIndex;

        _context.SaveChanges();

        var updatedArtwork = _mapper.Map<ArtworkDTO>(artwork);

        return updatedArtwork;
    }


    public void Delete(Guid id, string myUsername)
    {
      var record = _context.Artworks
        .Include(a => a.User)
        .Include(e => e.Likes)
        .Where(a => a.PublicId == id && a.User.Username == myUsername)
        .FirstOrDefault();

      if (record == null) {
        return;
      }

      _context.Artworks.Remove(record);
      _context.SaveChanges();
    }

    public List<string> GetTags()
    {
      var tags = _context.Tags
        .OrderByDescending(t => t.Artworks.Count())
        .Select(t => t.Title)
        .ToList();

      return tags;
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
        .OrderBy(t => t.Title)
        .Select(t => new TagDTO { Tag = t.Title })
        .ToList();

      return tags;
    }

    public bool Like(Guid artworkId, Guid mySocialId, out Guid owner)
    {
      owner = default(Guid);
      var artwork = _context.Artworks.Include(a => a.User).FirstOrDefault(a => a.PublicId == artworkId);
      var user = _context.Users.FirstOrDefault(u => u.SocialId == mySocialId);

      if (artwork == null || user == null)
      {
        return false;
      }
      owner = artwork.User.SocialId;
      var exists = _context.Likes
        .Count(l => l.ArtworkId == artwork.Id && l.UserId == user.Id);

      if (exists > 1)
      {
        Console.WriteLine("WARN: There are more than one ({0}) copies of likes for user {1} on artwork {2}", exists, user, artwork);
        return true;
      }
      else if (exists > 0)
      {
        return true;
      }

      _context.Likes.Add(
        new Like
        {
          ArtworkId = (int)artwork.Id,
          UserId = (int)user.Id,
          Date = DateTime.Now
        }
      );
      _context.SaveChanges();
      return true;
    }

    public bool Unlike(Guid artworkId, Guid mySocialId, out Guid owner)
    {
      owner = default(Guid);
      var record = _context.Likes
        .Include(l => l.Artwork)
        .ThenInclude(a => a.User)
        .Include(l => l.User)
        .Where(l => l.Artwork.PublicId == artworkId && l.User.SocialId == mySocialId)
        .FirstOrDefault();
      
      if (record == null)
      {
        return false;
      }
      owner = record.Artwork.User.SocialId;
      _context.Likes.Remove(record);
      _context.SaveChanges();
      return true;
    }

   public ArtworkDTO GetRandomArtwork(string owner)
      {
          var artwork = _context.Artworks
          .Where(a => a.User.Username == owner)
          .OrderBy(a => Guid.NewGuid()) 
          .Select(a => new
          {
              PrimaryFile = new
              {
                  Name = a.PrimaryFile.Name, 
                  Width = a.PrimaryFile.Width,
                  Height = a.PrimaryFile.Height,
              }
          })
          .FirstOrDefault();

      if (artwork == null || artwork.PrimaryFile == null)
        {
            return null;
        }

      return new ArtworkDTO
        {
            PrimaryFile = new FileDTO
            {
                Name = artwork.PrimaryFile.Name,
                Width = artwork.PrimaryFile.Width,
                Height = artwork.PrimaryFile.Height
            }
        };

      }



  }
}
