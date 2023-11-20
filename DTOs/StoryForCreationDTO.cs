using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class StoryForCreationDTO
  {
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(2000)]
    public string Description { get; set; }
    [Required]
    public string PrimaryFile { get; set; }
    public string SecondaryFile { get; set; }
    public string TertiaryFile { get; set; }
  }
}
