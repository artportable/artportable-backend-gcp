using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artportable.API.Entities.Models
{
  public class Exhibition
  {
    [Key]
    public int Id { get; set; }

    public int UserProfileId { get; set; }


    [Column(TypeName = "Text")]
    public string Name { get; set; }

    [MaxLength(140)]
    public string Place { get; set; }

    [Column(TypeName = "Date")]
    public DateTime? From { get; set; }

    [Column(TypeName = "Date")]
    public DateTime? To { get; set; }


    public UserProfile UserProfile { get; set; }
  }
}
