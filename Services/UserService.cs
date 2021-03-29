using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
using Microsoft.EntityFrameworkCore;
using System;
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

    public ProfileDTO GetProfile(Guid id)
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

      return new ProfileDTO()
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
        Followers = profile.User.FollowerRef.Count(),
        Followees = profile.User.FolloweeRef.Count(),
        Artworks = _context.Artworks.Count(a => a.UserId == profile.User.Id)
      };
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
