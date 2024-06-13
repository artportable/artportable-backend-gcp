using System;

namespace Artportable.API.DTOs
{
  public class StoryDTO
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Published { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string ProfilePicture { get; set; }

    public FileDTO PrimaryFile { get; set; }
    public FileDTO SecondaryFile { get; set; }
    public FileDTO TertiaryFile { get; set; }
    public string Slug {get; set;}
    public bool Exhibition { get; set; }
    public bool IsBoosted { get; set; }    
    public DateTime? BoostedAt { get; set; } 
  }
}
