using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artportable.API.Entities.Models
{
    [Table("platform_visits")]
    public class PlatformVisit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string SessionId { get; set; }

        [MaxLength(45)]
        public string IpAddress { get; set; }

        [Required]
        public DateTime VisitDate { get; set; } // Date only (for daily uniqueness)

        [Required]
        public DateTime VisitedAt { get; set; } // Full timestamp

        [MaxLength(200)]
        public string PageUrl { get; set; } // Which page they visited

        [MaxLength(200)]
        public string UserAgent { get; set; } // Browser info (optional)
    }
} 