using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class EducationDTO
  {
    [MaxLength(140)]
    public string Name { get; set; }
    [Range(1000, 9999)]
    public int? From { get; set; }
    [Range(1000, 9999)]
    public int? To { get; set; }
  }
}
