using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
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

    public UserDTO Get(Guid id) {
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

    public bool UserExists(Guid id)
    {
      return _context.Users.Any(u => u.PublicId == id);
    }

    public bool UserExists(UserDTO user)
    {
      return _context.Users.Any(u => u.Username == user.Username || u.Email == user.Email);
    }

    public Guid CreateUser(UserDTO user)
    {
      var publicId = Guid.NewGuid();
      var userDb = new User
      {
        PublicId = publicId,
        SubscriptionId = (int) SubscriptionEnum.Bas,
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
  }
}
