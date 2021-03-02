using System;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
    public interface IUserService
    {
      UserDTO Get(Guid id);
      Guid CreateUser(UserDTO user);
    }
}
