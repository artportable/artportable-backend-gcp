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
    public decimal? Price { get; set; }
    public FileDTO PrimaryFile { get; set; }
    public FileDTO SecondaryFile { get; set; }
    public FileDTO TertiaryFile { get; set; }
    public List<string> Tags { get; set; }
    public int Likes { get; set; }
    public bool LikedByMe { get; set; }
  }
}
