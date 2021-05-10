using System.Collections.Generic;

namespace Artportable.API.DTOs
{
  public class ArtistDTO
  {
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public string Location { get; set; }
    public List<FileDTO> Artworks { get; set; }
    public List<string> Tags { get; set; }
    public bool FollowedByMe { get; set; }
  }
}
