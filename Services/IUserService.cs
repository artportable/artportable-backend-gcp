using System;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IUserService
  {
    UserDTO Get(Guid id);
    ProfileDTO GetProfile(Guid id);
    bool UserExists(Guid id);
    bool UserExists(UserDTO user);
    bool UsernameExists(string username);
    bool EmailExists(string email);
    Guid CreateUser(UserDTO user);
  }
}
