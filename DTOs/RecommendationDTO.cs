using System;

namespace Artportable.API.DTOs
{
  public class RecommendationDTO
  {
    public string Username { get; set; }
    public Guid SocialId { get; set; }

    public string Location { get; set; }
    public string ProfilePicture { get; set; }
  }
}
