using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
  public class ArtworkDTO
  {
    public Guid Id { get; set; }
    public OwnerDTO Owner { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Published { get; set; }
    public string PrimaryFile { get; set; }
    public string SecondaryFile { get; set; }
    public string TertiaryFile { get; set; }
    public List<string> Tags { get; set; }
    public int Likes { get; set; }
    public bool LikedByMe { get; set; }
  }
}
