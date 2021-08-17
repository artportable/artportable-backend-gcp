using System;

namespace Artportable.API.DTOs
{
  public class UserImageDTO
  {
    public FileDTO Image { get; set; }
    public Guid ArtworkId { get; set; }
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
  }
}
