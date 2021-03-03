using System;
using System.ComponentModel.DataAnnotations;
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
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [MaxLength(50)]
    public string Location { get; set; }

    [MaxLength(50)]
    public string Title { get; set; }

    [MaxLength(140)]
    public string Headline { get; set; }


    public User User { get; set; }
  }
}
