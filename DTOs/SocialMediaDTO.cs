using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class SocialMediaDTO
  {
    [MaxLength(140)]
    public string Website { get; set; }
    [MaxLength(140)]
    public string Instagram { get; set; }
    [MaxLength(140)]
    public string Facebook { get; set; }
    [MaxLength(140)]
    public string LinkedIn { get; set; }
    [MaxLength(140)]
    public string Behance { get; set; }
    [MaxLength(140)]
    public string Dribble { get; set; }
  }
}
