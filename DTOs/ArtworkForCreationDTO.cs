using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class ArtworkForCreationDTO
  {
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(400)]
    public string Description { get; set; }
    public decimal? Price { get; set; }
    public decimal Height { get; set; }
    public decimal Width { get; set; }
    public decimal Depth { get; set; }
    [Required]
    public string PrimaryFile { get; set; }
    public string SecondaryFile { get; set; }
    public string TertiaryFile { get; set; }
    [MaxLength(5)]
    public List<string> Tags { get; set; }
  }
}
