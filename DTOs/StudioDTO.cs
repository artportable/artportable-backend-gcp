using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class StudioDTO
  {
    [MaxLength(140)]
    public string Text { get; set; }
    [MaxLength(140)]
    public string Location { get; set; }
  }
}
