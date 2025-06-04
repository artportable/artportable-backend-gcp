using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
    public class ProfileView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProfileUsername { get; set; }

        [Required]
        public DateTime ViewedAt { get; set; }

        [MaxLength(100)]
        public string SessionId { get; set; }

        [MaxLength(50)]
        public string IpAddress { get; set; }

        public DateTime ViewDate { get; set; } 
    }
} 