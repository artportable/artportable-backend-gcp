using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
  public class StoryForUpdateDTO
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PrimaryFile { get; set; }
    public string SecondaryFile { get; set; }
    public string TertiaryFile { get; set; }
    public string Slug {get; set;}

    public bool Exhibition { get; set; }

  }
}
