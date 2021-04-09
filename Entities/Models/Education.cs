using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artportable.API.Entities.Models
{
  public class Education
  {
    [Key]
    public int Id { get; set; }

    public int UserProfileId { get; set; }


    [MaxLength(140)]
    public string Name { get; set; }

    [Column(TypeName = "Year")]
    public int From { get; set; }

    [Column(TypeName = "Year")]
    public int To { get; set; }


    public UserProfile UserProfile { get; set; }
  }
}
