using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Entities.Models
{
    [Index(nameof(PublicId))]
    public class Story
    {
        [Key]
        public int Id { get; set; }
        public Guid PublicId { get; set; } //no
        [Required, MaxLength(240)]
        public string Title { get; set; }
        [Column(TypeName = "Text")]
        public string Description { get; set; }
        [Required]
        public DateTime Published { get; set; }

        public int UserId { get; set; }
        public int PrimaryFileId { get; set; }
        public int? SecondaryFileId { get; set; }
        public int? TertiaryFileId { get; set; }

        public User User { get; set; }
        public File PrimaryFile { get; set; }
        public File SecondaryFile { get; set; }
        public File TertiaryFile { get; set; }
        public ICollection<Tag> Tags { get; set; } // Nya taggar 
    }
}
