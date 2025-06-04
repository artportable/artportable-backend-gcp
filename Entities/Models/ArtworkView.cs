using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
    public class ArtworkView
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string ArtworkId { get; set; } // Artwork's PublicId (Guid as string)
        
        [Required]
        public DateTime ViewedAt { get; set; }
        
        [MaxLength(100)]
        public string SessionId { get; set; }
        
        [MaxLength(50)]
        public string IpAddress { get; set; }
        
        [Required]
        public DateTime ViewDate { get; set; } // Date only for grouping
    }
} 