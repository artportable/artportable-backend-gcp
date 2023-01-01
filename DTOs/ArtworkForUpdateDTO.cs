using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class ArtworkForUpdateDTO
  {
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(2000)]
    public string Description { get; set; }
    public decimal? Price { get; set; }
    public string? Currency {get; set;}
    public bool SoldOut { get; set; }
    public bool CuratedImage { get; set; }
    public bool MultipleSizes { get; set; }
    public decimal? Height { get; set; }
    public decimal? Width { get; set; }
    public decimal? Depth { get; set; }
    [Required]
    public string PrimaryFile { get; set; }
    public string SecondaryFile { get; set; }
    public string TertiaryFile { get; set; }
    [MaxLength(5)]
    public List<string> Tags { get; set; }
  }
}
