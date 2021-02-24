using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Username { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(150)]
        public string Profilepicture { get; set; }
    }
}
