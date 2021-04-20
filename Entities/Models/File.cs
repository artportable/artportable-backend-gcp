using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
  public class File
  {
    [Key]
    public int Id { get; set; }


    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }


    public Artwork PrimaryFileRef { get; set; }
    public Artwork SecondaryFileRef { get; set; }
    public Artwork TertiaryFileRef { get; set; }
  }
}
