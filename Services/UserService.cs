using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artportable.API.Services
{
  public class UserService : IUserService
  {
    private APContext _context;
    private readonly IMapper _mapper;

    public UserService(APContext apContext, IMapper mapper)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    public UserDTO Get(Guid id)
    {
      var user = _context.Users
        .Where(i => i.PublicId == id)
        .Join(_context.UserProfiles,
          user => user.Id,
          profile => profile.UserId,
          (user, profile) => new { User = user, Profile = profile })
        .SingleOrDefault();

      return user != null ? new UserDTO()
      {
        Username = user.User.Username,
        Name = user.Profile.Name,
        Surname = user.Profile.Surname,
        Email = user.User.Email,
        DateOfBirth = user.Profile.DateOfBirth,
        Location = user.Profile.Location
      } :
      null;
    }

    public ProfileSummaryDTO GetProfileSummary(Guid id)
    {
      var user = _context.Users
        .Include(u => u.UserProfile)
        .Include(u => u.File)
        .Include(u => u.FollowerRef)
        .Include(u => u.FolloweeRef)
        .Where(i => i.PublicId == id)
        .SingleOrDefault();

      if (user == null) {
        return null;
      }

      return new ProfileSummaryDTO()
      {
        Username = user.Username,
        ProfilePicture = user.File?.Name,
        Headline = user.UserProfile.Headline,
        Title = user.UserProfile.Title,
        Location = user.UserProfile.Location,
        Followers = user.FollowerRef.Count(),
        Followees = user.FolloweeRef.Count(),
        Artworks = _context.Artworks.Count(a => a.UserId == user.Id)
      };
    }

    public ProfileDTO GetProfile(Guid id, Guid? userId)
    {
      var profile = _context.UserProfiles
        .Include(up => up.User)
        .ThenInclude(u => u.File)
        .Include(up => up.User.CoverPhotoFile)
        .Include(up => up.Educations)
        .Include(up => up.Exhibitions)
        .Where(i => i.User.PublicId == id)
        .SingleOrDefault();

      if (profile == null) {
        return null;
      }

      var dto = _mapper.Map<ProfileDTO>(profile);

      if (userId != null)
      {
        dto.FollowedByMe = _context.Connections.Any(c => c.Followee.PublicId == id && c.Follower.PublicId == userId);
      }

      return dto;
    }

    public ProfileDTO UpdateProfile(Guid id, UpdateProfileDTO updatedProfile)
    {
      var rowToUpdate = _context.UserProfiles
        .Include(up => up.User)
        .Include(up => up.User.File)
        .Include(up => up.User.CoverPhotoFile)
        .Include(up => up.Educations)
        .Include(up => up.Exhibitions)
        .FirstOrDefault(up => up.User.PublicId == id);

      if (rowToUpdate == null)
      {
        return null;
      }

      setSafely(updatedProfile.Headline, val => { rowToUpdate.Headline = val; });
      setSafely(updatedProfile.Title, val => { rowToUpdate.Title = val; });
      setSafely(updatedProfile.Location, val => { rowToUpdate.Location = val; });
      setSafely(updatedProfile.Name, val => { rowToUpdate.Name = val; });
      setSafely(updatedProfile.Surname, val => { rowToUpdate.Surname = val; });
      setSafely(updatedProfile.About, val => { rowToUpdate.About = val; });
      setSafely(updatedProfile.InspiredBy, val => { rowToUpdate.InspiredBy = val; });
      setSafely(updatedProfile.StudioText, val => { rowToUpdate.StudioText = val; });
      setSafely(updatedProfile.StudioLocation, val => { rowToUpdate.StudioLocation = val; });
      setSafely(updatedProfile.Website, val => { rowToUpdate.Website = val; });
      setSafely(updatedProfile.InstagramUrl, val => { rowToUpdate.InstagramUrl = val; });
      setSafely(updatedProfile.FacebookUrl, val => { rowToUpdate.FacebookUrl = val; });
      setSafely(updatedProfile.LinkedInUrl, val => { rowToUpdate.LinkedInUrl = val; });
      setSafely(updatedProfile.BehanceUrl, val => { rowToUpdate.BehanceUrl = val; });
      setSafely(updatedProfile.DribbleUrl, val => { rowToUpdate.DribbleUrl = val; });

      if (updatedProfile.Educations != null)
      {
        rowToUpdate.Educations = updatedProfile.Educations.Select(e => new Education()
          {
            Name = e.Name,
            From = e.From,
            To = e.To
          }
        ).ToList();
      }

      if (updatedProfile.Exhibitions != null)
      {
        rowToUpdate.Exhibitions = updatedProfile.Exhibitions.Select(e => new Exhibition()
          {
            Name = e.Name,
            Place = e.Place,
            From = e.From,
            To = e.To
          }
        ).ToList();
      }

      _context.SaveChanges();

      var dto = _mapper.Map<ProfileDTO>(rowToUpdate);

      return dto;
    }

    public List<SimilarProfileDTO> GetSimilarProfiles(Guid id)
    {
      return _context.Users // TODO: Order by relevance (tags)
        .Include(u => u.File)
        .Include(u => u.Artworks)
        .Where(u => u.PublicId != id)
        .Where(u => u.Artworks.Any())
        .Take(3)
        .Select(u =>
        new SimilarProfileDTO
        {
          Id = u.PublicId,
          Username = u.Username,
          ProfilePicture = u.File.Name,
          Artworks = _context.Artworks
            .Include(a => a.PrimaryFile)
            .Where(a => a.UserId == u.Id)
            .Take(5)
            .Select(a => a.PrimaryFile.Name)
            .ToList()
        })
        .ToList();
    }

    public List<TagDTO> GetTags(Guid id)
    {
      return _context.Tags
        .Where(t => t.Artworks.Any(a => a.User.PublicId == id))
        .Select(t => new TagDTO { Tag = t.Title })
        .ToList();
    }

    public bool UserExists(Guid id)
    {
      return _context.Users.Any(u => u.PublicId == id);
    }

    public bool UserExists(UserDTO user)
    {
      return _context.Users.Any(u => u.Username == user.Username || u.Email == user.Email);
    }

    public bool UsernameExists(string username)
    {
      return _context.Users.Any(u => u.Username == username);
    }

    public bool EmailExists(string email)
    {
      return _context.Users.Any(u => u.Email == email);
    }

    public Guid CreateUser(UserDTO user)
    {
      var subscriptionDb = new Entities.Models.Subscription
      {
        ProductId = (int) ProductEnum.Bas,
        CustomerId = null,
        ExpirationDate = null
      };

      var publicId = Guid.NewGuid();
      var userDb = new User
      {
        PublicId = publicId,
        Subscription = subscriptionDb,
        Username = user.Username,
        Email = user.Email,
        Created = DateTime.Now,
        Language = "en"
      };

      var profileDb = new UserProfile
      {
        Name = user.Name,
        Surname = user.Surname,
        DateOfBirth = user.DateOfBirth,
        Location = user.Location,
        User = userDb
      };
      _context.UserProfiles.Add(profileDb);

      _context.SaveChanges();

      return publicId;
    }
    public Guid? Login(string email)
    {
      return _context.Users
        .Where(u => u.Email == email)
        .SingleOrDefault()
        ?.PublicId;
    }

    private void setSafely<T>(T value, Action<T> setAction) {
      if(value != null) {
        setAction(value);
      }
    }
  }
}
