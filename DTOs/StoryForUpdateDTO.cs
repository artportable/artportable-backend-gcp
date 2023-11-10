using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
  public class StoryForUpdateDTO
  {
    public Guid Id { get; set; }
    public OwnerDTO Owner { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Published { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string PrimaryFile { get; set; }
    public string SecondaryFile { get; set; }
    public string TertiaryFile { get; set; }
  }
}
