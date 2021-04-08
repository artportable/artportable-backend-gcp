using System;

namespace Artportable.API.DTOs
{
  public class ExhibitionDTO
  {
    public string Name { get; set; }
    public string Place { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
  }
}
