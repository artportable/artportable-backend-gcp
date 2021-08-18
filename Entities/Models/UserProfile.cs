using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Entities.Models
{
  [Index(nameof(UserId), IsUnique = true)]
  public class UserProfile
  {
    [Key]
    public int Id { get; set; }


    public int UserId { get; set; }


    [Required]
    [MaxLength(140)]
    public string Name { get; set; }

    [Required]
    [MaxLength(140)]
    public string Surname { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [MaxLength(140)]
    public string Location { get; set; }

    [MaxLength(140)]
    public string Title { get; set; }

    [MaxLength(140)]
    public string Headline { get; set; }

    [Column(TypeName = "Text")]
    public string About { get; set; }

    [Column(TypeName = "Text")]
    public string InspiredBy { get; set; }

    [MaxLength(280)]
    public string StudioText { get; set; }

    [MaxLength(140)]
    public string StudioLocation { get; set; }

    [MaxLength(280)]
    public string Website { get; set; }

    [MaxLength(280)]
    public string InstagramUrl { get; set; }

    [MaxLength(280)]
    public string FacebookUrl { get; set; }

    [MaxLength(280)]
    public string LinkedInUrl { get; set; }

    [MaxLength(280)]
    public string BehanceUrl { get; set; }

    [MaxLength(280)]
    public string DribbleUrl { get; set; }

    [Column(TypeName = "Text")]
    public string Technique { get; set; }


    public User User { get; set; }
    public IEnumerable<Education> Educations { get; set; }
    public IEnumerable<Exhibition> Exhibitions { get; set; }
  }
}
