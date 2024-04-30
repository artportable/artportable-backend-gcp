using System;

namespace Artportable.API.DTOs
{
  public class ProfileSummaryDTO
  {
    public string Username { get; set; }
    public Guid SocialId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ProfilePicture { get; set; }
    public string Headline { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Country {get; set;}
    public string State {get; set;}
    public string City {get; set;}
    public int Followers { get; set; }
    public int Followees { get; set; }
    public int Artworks { get; set; }
    public bool HideLikedArtworks { get; set; }

    public DateTime? EmailInformedFollowersDate { get; set; }
    public bool EmailReceiveArtworkUploaded { get; set; } 
    

  }
}
