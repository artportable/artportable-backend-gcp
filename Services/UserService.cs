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
        Educations = profile.Educations?.Select(e => new EducationDTO {
          Name = e.Name,
          From = e.From,
          To = e.To
        }).ToList(),
        Exhibitions = profile.Exhibitions?.Select(e => new ExhibitionDTO {
          Name = e.Name,
          Place = e.Place,
          From = e.From,
          To = e.To
        }).ToList()
      };
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

      return new ProfileDTO() // TODO: Automap this
      {
        Username = rowToUpdate.User.Username,
        ProfilePicture = rowToUpdate.User.File?.Name,
        Headline = rowToUpdate.Headline,
        Title = rowToUpdate.Title,
        Location = rowToUpdate.Location,

        CoverPhoto = rowToUpdate.User.CoverPhotoFile?.Name,
        Name = rowToUpdate.Name,
        Surname = rowToUpdate.Surname,
        About = rowToUpdate.About,
        InspiredBy = rowToUpdate.InspiredBy,
        StudioText = rowToUpdate.StudioText,
        StudioLocation = rowToUpdate.StudioLocation,
        Website = rowToUpdate.Website,
        InstagramUrl = rowToUpdate.InstagramUrl,
        FacebookUrl = rowToUpdate.FacebookUrl,
        LinkedInUrl = rowToUpdate.LinkedInUrl,
        BehanceUrl = rowToUpdate.BehanceUrl,
        DribbleUrl = rowToUpdate.DribbleUrl,
        Educations = rowToUpdate.Educations?.Select(e => new EducationDTO {
          Name = e.Name,
          From = e.From,
          To = e.To
        }).ToList(),
        Exhibitions = rowToUpdate.Exhibitions?.Select(e => new ExhibitionDTO {
          Name = e.Name,
          Place = e.Place,
          From = e.From,
          To = e.To
        }).ToList()
      };;
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
