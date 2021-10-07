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

    public string InspiredBy { get; set; }
    public StudioDTO Studio { get; set; }
    public SocialMediaDTO SocialMedia { get; set; }

    public ICollection<EducationDTO> Educations { get; set; }

    public ICollection<ExhibitionDTO> Exhibitions { get; set; }
  }
}
