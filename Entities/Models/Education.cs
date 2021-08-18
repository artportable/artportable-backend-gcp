using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artportable.API.Entities.Models
{
  public class Education
  {
    [Key]
    public int Id { get; set; }

    public int UserProfileId { get; set; }


    [Column(TypeName = "Text")]
    public string Name { get; set; }
    public int? From { get; set; }
    public int? To { get; set; }


    public UserProfile UserProfile { get; set; }
  }
}
