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


    public User User { get; set; }
  }
}
