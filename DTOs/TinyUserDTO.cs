using System;

namespace Artportable.API.DTOs
{
  public class TinyUserDTO
  {
    public string Username { get; set; }
    public string ProfilePicture { get; set; }
    public string Email {get; set;}
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Product { get; set; }
    public Guid SocialId { get; set; }
  }
}
