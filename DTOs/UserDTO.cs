using System;

namespace Artportable.API.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
    }
}
