using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Entities.Models
{
  [Index(nameof(PublicId))]
  public class Artwork
  {
    [Key]
    public int Id { get; set; }
    public Guid PublicId { get; set; }


    public int UserId { get; set; }
    public int PrimaryFileId { get; set; }
    public int? SecondaryFileId { get; set; }
    public int? TertiaryFileId { get; set; }


    [MaxLength(240)]
    public string Title { get; set; }

    [MaxLength(2000)]
    public string Description { get; set; }

    [Required]
    public DateTime Published { get; set; }

    public decimal? Price { get; set; }

    public string? Currency {get; set;}
    public bool SoldOut { get; set; }
    public bool MultipleSizes { get; set; }
    public decimal? Height { get; set; }
    public decimal? Width { get; set; }
    public decimal? Depth { get; set; }

    public User User { get; set; }
    public File PrimaryFile { get; set; }
    public File SecondaryFile { get; set; }
    public File TertiaryFile { get; set; }

    public ICollection<Tag> Tags { get; set; }
    public ICollection<Like> Likes { get; set; }
  }
}
