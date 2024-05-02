using System;

namespace Artportable.API.DTOs
{
  public class OwnerDTO
  {
    public string Username { get; set; }
    public Guid SocialId { get; set; }
    public string ProfilePicture { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Location { get; set; }
    public bool FollowedByMe { get; set; }
    public bool MonthlyArtist { get; set; }
    public DateTime? EmailInformedFollowersDate { get; set; } 
    public bool EmailDeclinedArtworkUpload { get; set; } 
    public string Email { get; set; }
    
  
  }
}
