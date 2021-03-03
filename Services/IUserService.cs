using System;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IUserService
  {
    UserDTO Get(Guid id);
    bool UserExists(Guid id);
    bool UserExists(UserDTO user);
    Guid CreateUser(UserDTO user);
  }
}
