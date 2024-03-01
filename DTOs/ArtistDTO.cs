using System.Collections.Generic;
using System;

namespace Artportable.API.DTOs
{
  public class ArtistDTO
  {
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid SocialId { get; set; }
    public string Location { get; set; }
    public List<TinyArtworkDTO> Artworks { get; set; }
    public List<string> Tags { get; set; }
    public bool FollowedByMe { get; set; }
    public bool MonthlyArtist { get; set; }
    public bool BoostUser {get; set;}
  }
}
