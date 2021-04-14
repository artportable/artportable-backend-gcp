using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class ExhibitionDTO
  {
    [MaxLength(140)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Place { get; set; }
    // MySQL DATE: The supported range is '1000-01-01' to '9999-12-31'.
    public DateTime From { get; set; }
    public DateTime To { get; set; }
  }
}
