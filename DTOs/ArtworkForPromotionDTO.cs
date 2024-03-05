using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class ArtworkForPromotionDTO
  {
    [Required]   
    public bool Promoted {get; set;}
  }
}
