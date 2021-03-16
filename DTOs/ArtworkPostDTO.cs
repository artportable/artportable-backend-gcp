using System;

namespace Artportable.API.DTOs
{
  public class ArtworkPostDTO
  {
    public Guid Id { get; set; }
    public string PrimaryFile { get; set; }
    public string SecondaryFile { get; set; }
    public string TertiaryFile { get; set; }
  }
}
