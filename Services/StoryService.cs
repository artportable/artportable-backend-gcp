using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Services
{
  public class StoryService : IStoryService
  {
    private APContext _context;
    private readonly IMapper _mapper;

    public StoryService(APContext apContext, IMapper mapper)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    public List<StoryDTO> Get(string owner, string myUsername)
    {
      var ownerProductId = _context.Users
        .Include(u => u.Subscription)
        .SingleOrDefault(u => u.Username == owner)?.Subscription?.ProductId;
      if (ownerProductId == (int)ProductEnum.Bas)
      {
        return new List<StoryDTO>();
      }

      return _context.Stories
        .Where(s => owner != null ? s.User.Username == owner : true)
        .OrderByDescending(s => s.Published)
        .Select(s =>
        new StoryDTO
        {
          Id = s.PublicId,
          Title = s.Title,
          Description = s.Description,
          Published = s.Published,
          Name = s.User.UserProfile.Name,
          Surname = s.User.UserProfile.Surname,
          Username = s.User.Username,
          ProfilePicture = s.User.File.Name,
          PrimaryFile = new FileDTO
          {
            Name = s.PrimaryFile.Name,
            Width = s.PrimaryFile.Width,
            Height = s.PrimaryFile.Height
          },
          SecondaryFile = s.SecondaryFile != null ? new FileDTO
          {
            Name = s.SecondaryFile.Name,
            Width = s.SecondaryFile.Width,
            Height = s.SecondaryFile.Height
          } : null,
          TertiaryFile = s.TertiaryFile != null ? new FileDTO
          {
            Name = s.TertiaryFile.Name,
            Width = s.TertiaryFile.Width,
            Height = s.TertiaryFile.Height
          } : null,
        })
        .ToList();
    }

    public StoryDTO Get(Guid id, string myUsername)
    {
      var story = _context.Stories
        .Where(s => s.PublicId == id)
        .Select(s => new
        {
          PublicId = s.PublicId,
          User = new
          {
            Username = s.User.Username,
            Name = s.User.UserProfile.Name,
            Surname = s.User.UserProfile.Surname,
            File = s.User.File != null ? new
            {
              Name = s.User.File.Name
            } : null,
            MonthlyUser = s.User.MonthlyUser
          },
          Title = s.Title,
          Description = s.Description,
          Published = s.Published,
          PrimaryFile = new
          {
            Name = s.PrimaryFile.Name,
            Width = s.PrimaryFile.Width,
            Height = s.PrimaryFile.Height,
          },
          SecondaryFile = s.SecondaryFile != null ? new
          {
            Name = s.SecondaryFile.Name,
            Width = s.SecondaryFile.Width,
            Height = s.SecondaryFile.Height,
          } : null,
          TertiaryFile = s.TertiaryFile != null ? new
          {
            Name = s.TertiaryFile.Name,
            Width = s.TertiaryFile.Width,
            Height = s.TertiaryFile.Height,
          } : null
        })
        .SingleOrDefault();

      if (story == null)
      {
        return null;
      }

      return new StoryDTO
      {
        Id = story.PublicId,
        Title = story.Title,
        Description = story.Description,
        Published = story.Published,
        Name = story.User.Name,
        Surname = story.User.Surname,
        Username = story.User.Username,
        ProfilePicture = story.User.File.Name,
        PrimaryFile = new FileDTO
        {
          Name = story.PrimaryFile.Name,
          Width = story.PrimaryFile.Width,
          Height = story.PrimaryFile.Height
        },
        SecondaryFile = story.SecondaryFile != null ? new FileDTO
        {
          Name = story.SecondaryFile.Name,
          Width = story.SecondaryFile.Width,
          Height = story.SecondaryFile.Height
        } : null,
        TertiaryFile = story.TertiaryFile != null ? new FileDTO
        {
          Name = story.TertiaryFile.Name,
          Width = story.TertiaryFile.Width,
          Height = story.TertiaryFile.Height
        } : null,
      };
    }

    public List<StoryDTO> GetLatestStories(int page, int pageSize, ProductEnum minimumProduct = ProductEnum.Portfolio)
    {
      return _context.Stories
        .Where(s => s.User.Subscription.ProductId >= (int)minimumProduct)
        .OrderByDescending(s => s.Published)
        .Skip(pageSize * (page - 1))
        .Take(pageSize)
        .Select(s =>
        new StoryDTO
        {
          Id = s.PublicId,
          Title = s.Title,
          Name = s.User.UserProfile.Name,
          Surname = s.User.UserProfile.Surname,
          Username = s.User.Username,
          Description = s.Description,
          Published = s.Published,
          PrimaryFile = new FileDTO
          {
            Name = s.PrimaryFile.Name,
            Width = s.PrimaryFile.Width,
            Height = s.PrimaryFile.Height
          },
          SecondaryFile = s.SecondaryFile != null ? new FileDTO
          {
            Name = s.SecondaryFile.Name,
            Width = s.SecondaryFile.Width,
            Height = s.SecondaryFile.Height
          } : null,
          TertiaryFile = s.TertiaryFile != null ? new FileDTO
          {
            Name = s.TertiaryFile.Name,
            Width = s.TertiaryFile.Width,
            Height = s.TertiaryFile.Height
          } : null,
        })
        .ToList();
    }
    
    public StoryDTO Create(StoryForCreationDTO dto, Guid mySocialId)
    {
      var user = _context.Users.FirstOrDefault(u => u.SocialId == mySocialId);

      if (user == null)
      {
        return null;
      }

      var story = new Story
      {
        PublicId = Guid.NewGuid(),
        User = user,
        Title = dto.Title,
        Description = dto.Description,
        Published = DateTime.Now,
        PrimaryFile = _context.Files.Where(f => f.Name == dto.PrimaryFile).SingleOrDefault(),
        SecondaryFile = dto.SecondaryFile != null ? _context.Files.Where(f => f.Name == dto.SecondaryFile).SingleOrDefault() : null,
        TertiaryFile = dto.TertiaryFile != null ? _context.Files.Where(f => f.Name == dto.TertiaryFile).SingleOrDefault() : null,
      };


      _context.Add(story);
      _context.SaveChanges();

      var storyDTO = _mapper.Map<StoryDTO>(story);

      return storyDTO;
    }

    public StoryDTO Update(StoryForUpdateDTO dto, Guid id, Guid mySocialId)
    {
      var story = _context.Stories
        .Include(s => s.User)
        .Include(s => s.PrimaryFile)
        .Include(s => s.SecondaryFile)
        .Include(s => s.TertiaryFile)
        .FirstOrDefault(s => s.PublicId == id && s.User.SocialId == mySocialId);

      if (story == null)
      {
        return null;
      }
      story.Title = dto.Title;
      story.Description = dto.Description;

      if (story.PrimaryFile.Name != dto.PrimaryFile)
      {
        var fileToRemove = story.PrimaryFile;
        _context.Files.Remove(fileToRemove);
        story.PrimaryFile = new File { Name = dto.PrimaryFile };
      }
      if (story.SecondaryFile?.Name != dto.PrimaryFile)
      {
        if (story?.SecondaryFile != null)
        {
          var fileToRemove = story?.SecondaryFile;
          _context.Files.Remove(fileToRemove);
        }
        if (dto.SecondaryFile != null)
        {
          story.SecondaryFile = new File { Name = dto.SecondaryFile };
        }
      }
      if (story.TertiaryFile?.Name != dto.TertiaryFile)
      {
        if (story?.TertiaryFile != null)
        {
          var fileToRemove = story?.TertiaryFile;
          _context.Files.Remove(fileToRemove);
        }
        if (dto.TertiaryFile != null)
        {
          story.TertiaryFile = new File { Name = dto.TertiaryFile };
        }
      }

      _context.Update(story);
      _context.SaveChanges();

      var storyDTO = _mapper.Map<StoryDTO>(story);

      return storyDTO;
    }

    public void Delete(Guid id, string myUsername)
    {
      var record = _context.Stories
        .Include(s => s.User)
        .Where(s => s.PublicId == id && s.User.Username == myUsername)
        .FirstOrDefault();

      if (record == null)
      {
        return;
      }

      _context.Stories.Remove(record);
      _context.SaveChanges();
    }

  }
}
