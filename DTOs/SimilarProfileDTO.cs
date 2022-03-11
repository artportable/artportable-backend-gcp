using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
  public class SimilarProfileDTO
  {
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<FileDTO> Artworks { get; set; }
  }
}
