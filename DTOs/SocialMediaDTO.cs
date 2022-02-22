using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class SocialMediaDTO
  {
    [MaxLength(280)]
    public string Website { get; set; }
    [MaxLength(280)]
    public string Instagram { get; set; }
    [MaxLength(280)]
    public string Facebook { get; set; }
    [MaxLength(280)]
    public string LinkedIn { get; set; }
    [MaxLength(280)]
    public string Behance { get; set; }
    [MaxLength(280)]
    public string Dribble { get; set; }
  }
}
