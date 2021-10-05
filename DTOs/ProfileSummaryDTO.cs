using System;

namespace Artportable.API.DTOs
{
  public class ProfileSummaryDTO
  {
    public string Username { get; set; }
    public Guid? KeycloakId { get; set; }
    public string ProfilePicture { get; set; }
    public string Headline { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public int Followers { get; set; }
    public int Followees { get; set; }
    public int Artworks { get; set; }
  }
}
