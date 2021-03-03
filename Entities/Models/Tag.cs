using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
  public class Tag
  {
    [Key]
    public int Id { get; set; }


    [Required]
    [MaxLength(100)]
    public string Title { get; set; }


    public ICollection<Artwork> Artworks { get; set; }
  }
}
