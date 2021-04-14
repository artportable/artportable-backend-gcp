using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class UpdateProfileDTO
  {
    [StringLength(140)]
    public string Headline { get; set; }

    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(50)]
    public string Location { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Surname { get; set; }
    public string About { get; set; }

    [MaxLength(140)]
    public string InspiredBy { get; set; }

    [MaxLength(140)]
    public string StudioText { get; set; }

    [MaxLength(140)]
    public string StudioLocation { get; set; }

    [MaxLength(140)]
    public string Website { get; set; }

    [MaxLength(140)]
    public string InstagramUrl { get; set; }

    [MaxLength(140)]
    public string FacebookUrl { get; set; }

    [MaxLength(140)]
    public string LinkedInUrl { get; set; }

    [MaxLength(140)]
    public string BehanceUrl { get; set; }

    [MaxLength(140)]
    public string DribbleUrl { get; set; }

    public ICollection<EducationDTO> Educations { get; set; }

    public ICollection<ExhibitionDTO> Exhibitions { get; set; }
  }
}
