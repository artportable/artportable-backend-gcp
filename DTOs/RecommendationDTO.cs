using System;

namespace Artportable.API.DTOs
{
  public class RecommendationDTO
  {
    public Guid UserId { get; set; }

    public string Username { get; set; }

    public string Location { get; set; }
    public string ProfilePicture { get; set; }
  }
}
