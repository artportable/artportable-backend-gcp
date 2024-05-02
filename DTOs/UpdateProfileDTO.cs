using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class UpdateProfileDTO
  {
    [StringLength(140)]
    public string Headline { get; set; }

    [MaxLength(140)]
    public string Title { get; set; }
    [MaxLength(280)]
    public string Location { get; set; }
    [MaxLength(140)]

    public string Country {get; set;}

    [MaxLength(140)]
    public string State {get; set;}
    public string City {get; set;}
    [MaxLength(140)]
    public string Name { get; set; }
    [MaxLength(140)]
    public string Surname { get; set; }
    public string About { get; set; }

    public string InspiredBy { get; set; }
    public StudioDTO Studio { get; set; }
    public SocialMediaDTO SocialMedia { get; set; }

    public ICollection<EducationDTO> Educations { get; set; }

    public ICollection<ExhibitionDTO> Exhibitions { get; set; }
    public bool HideLikedArtworks { get; set; }

    public DateTime? EmailInformedFollowersDate { get; set; }

    public bool EmailDeclinedArtworkUpload { get; set; } 


  }
}
