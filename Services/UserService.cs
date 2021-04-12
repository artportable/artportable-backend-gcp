using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artportable.API.Services
{
  public class UserService : IUserService
  {
    private APContext _context;

    public UserService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
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

    public ProfileDTO GetProfile(Guid id)
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

      return new ProfileDTO()
      {
        Username = profile.User.Username,
        ProfilePicture = profile.User.File?.Name,
        Headline = profile.Headline,
        Title = profile.Title,
        Location = profile.Location,

        CoverPhoto = profile.User.CoverPhotoFile?.Name,
        Name = profile.Name,
        Surname = profile.Surname,
        About = profile.About,
        InspiredBy = profile.InspiredBy,
        StudioText = profile.StudioText,
        StudioLocation = profile.StudioLocation,
        Website = profile.Website,
        InstagramUrl = profile.InstagramUrl,
        FacebookUrl = profile.FacebookUrl,
        LinkedInUrl = profile.LinkedInUrl,
        BehanceUrl = profile.BehanceUrl,
        DribbleUrl = profile.DribbleUrl,
        Educations = profile.Educations.Select(e => new EducationDTO {
          Name = e.Name,
          From = e.From,
          To = e.To
        }).ToList(),
        Exhibitions = profile.Exhibitions.Select(e => new ExhibitionDTO {
          Name = e.Name,
          Place = e.Place,
          From = e.From,
          To = e.To
        }).ToList()
      };
    }

    public ProfileDTO UpdateProfile(Guid id, UpdateProfileDTO updatedProfile) {
      var profile = _context.UserProfiles
        .Include(up => up.User)
        .Include(u => u.User.FollowerRef)
        .Include(u => u.User.FolloweeRef)
        .SingleOrDefault(up => up.User.PublicId == id);

      if(profile == null) 
      {
        return null;
      }


      void setSafely<T>(T value, Action<T> setAction) {
        if(value != null) {
          setAction(value);
        }
      } 

      setSafely(updatedProfile.Headline, h => { profile.Headline = h; });
      setSafely(updatedProfile.Title, t => { profile.Title = t; });
      setSafely(updatedProfile.Location, l => { profile.Location = l; });
      //TODO: Profile picture?
      //profile.User.File = updatedProfile.ProfilePicture;

      _context.SaveChanges();

      return new ProfileDTO()
      {
        Username = profile.User.Username,
        ProfilePicture = profile.User.File?.Name,
        Headline = profile.Headline,
        Title = profile.Title,
        Location = profile.Location,
      };
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
  }
}
