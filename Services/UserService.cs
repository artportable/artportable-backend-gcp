using Artportable.API.DTOs;
using System;

namespace Artportable.API.Services
{
    public class UserService : IUserService
    {
        // private UserContext _context;
        
        public UserDTO Get(Guid id) {
          return new UserDTO() { Name = "Kalle", Surname = "Banan" };
        }

        public Guid CreateUser(UserDTO user)
        {
          // Check so that user doesn't already exist and create a new user
          // _context.Users.Add(user);
          Console.WriteLine("User created.");
          return new Guid("9eb6ec7b-943d-4064-83ba-283f33cba340");
        }
    }
}
