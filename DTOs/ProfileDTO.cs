using System.Collections.Generic;

namespace Artportable.API.DTOs
{
  public class ProfileDTO
  {
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public string Headline { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }

    public string CoverPhoto { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string About { get; set; }
    public string InspiredBy { get; set; }
    public string StudioText { get; set; }
    public string StudioLocation { get; set; }
    public string Website { get; set; }
    public string InstagramUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string LinkedInUrl { get; set; }
    public string BehanceUrl { get; set; }
    public string DribbleUrl { get; set; }
    public List<EducationDTO> Educations { get; set; }
    public List<ExhibitionDTO> Exhibitions { get; set; }
  }
}
