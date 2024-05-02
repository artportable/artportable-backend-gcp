using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
  public class ProfileDTO
  {
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public string CoverPhoto { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Headline { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Country {get; set;}
    public string State {get; set;}
    public string City {get; set;}
    public string About { get; set; }
    public string InspiredBy { get; set; }
    public StudioDTO Studio { get; set; }
    public SocialMediaDTO SocialMedia { get; set; }
    public List<EducationDTO> Educations { get; set; }
    public List<ExhibitionDTO> Exhibitions { get; set; }

    public bool FollowedByMe { get; set; }
    public bool MonthlyArtist { get; set; }
    public DateTime? EmailInformedFollowersDate { get; set; }
    public bool EmailDeclinedArtworkUpload { get; set; } 
  }
}
