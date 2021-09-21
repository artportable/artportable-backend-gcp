using System;

namespace Artportable.API.DTOs
{
  public class TinyArtworkDTO
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public FileDTO PrimaryFile { get; set; }
  }
}
