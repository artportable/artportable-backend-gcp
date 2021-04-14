using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
  public class SimilarProfileDTO
  {
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public List<string> Artworks { get; set; }
  }
}
