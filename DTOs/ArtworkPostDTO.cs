using System;

namespace Artportable.API.DTOs
{
  public class ArtworkPostDTO
  {
    public Guid Id { get; set; }
    public FileDTO PrimaryFile { get; set; }
    public FileDTO SecondaryFile { get; set; }
    public FileDTO TertiaryFile { get; set; }
  }
}
