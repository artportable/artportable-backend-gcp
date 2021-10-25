using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class StartDeliverUserSyncDTO
  {
    [MaxLength(140)]
    public string email { get; set; }
    [MaxLength(140)]
    public string username { get; set; }
  }
}
