using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Artportable.API.DTOs
{
  public class StartDeliverUserSyncDTO
  {
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }
  }
}
