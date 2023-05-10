using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Entities.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        [MaxLength(254)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Like> Likes { get; set; }

        public User User { get; set; }
    }
}
