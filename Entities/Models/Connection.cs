using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
  public class Connection
  {
    [Key]
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FolloweeId { get; set; }


    public User Follower { get; set; }
    public User Followee { get; set; }
  }
}
