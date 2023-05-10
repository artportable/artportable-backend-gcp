using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
  public class Like
  {
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }
    public int ArtworkId { get; set; }
    public int? PostId { get; set; }

    public DateTime Date { get; set;}

    public User User { get; set; }
    public Artwork Artwork { get; set; }
    public Post Post { get; set; }
  }
}
