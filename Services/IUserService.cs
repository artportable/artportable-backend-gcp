using System;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IUserService
  {
    UserDTO Get(Guid id);
    ProfileSummaryDTO GetProfileSummary(Guid id);
    ProfileDTO GetProfile(Guid id, Guid? userId);
    ProfileDTO UpdateProfile(Guid id, UpdateProfileDTO updatedProfile);
    bool UserExists(Guid id);
    bool UserExists(UserDTO user);
    bool UsernameExists(string username);
    bool EmailExists(string email);
    Guid CreateUser(UserDTO user);
    Guid? Login(string email);
  }
}
