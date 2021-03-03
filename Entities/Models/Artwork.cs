using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
  public class Artwork
  {
    [Key]
    public int Id { get; set; }
    public Guid PublicId { get; set; }


    public int UserId { get; set; }
    public int FileId { get; set; }


    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(400)]
    public string Description { get; set; }

    [Required]
    public DateTime Published { get; set; }


    public User User { get; set; }
    public File File { get; set; }

    public ICollection<Tag> Tags { get; set; }
  }
}
