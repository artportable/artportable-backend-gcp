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
    public int PrimaryFileId { get; set; }
    public int? SecondaryFileId { get; set; }
    public int? TertiaryFileId { get; set; }


    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(800)]
    public string Description { get; set; }

    [Required]
    public DateTime Published { get; set; }

    public decimal Price { get; set; }


    public User User { get; set; }
    public File PrimaryFile { get; set; }
    public File SecondaryFile { get; set; }
    public File TertiaryFile { get; set; }

    public ICollection<Tag> Tags { get; set; }
    public ICollection<Like> Likes { get; set; }
  }
}
