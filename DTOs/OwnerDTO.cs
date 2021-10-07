using System;

namespace Artportable.API.DTOs
{
  public class OwnerDTO
  {
    public string Username { get; set; }
    public Guid SocialId { get; set; }
    public string ProfilePicture { get; set; }
    public string Location { get; set; }
    public bool FollowedByMe { get; set; }
  }
}
