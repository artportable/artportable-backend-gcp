using System.Text.Json.Serialization;

namespace Artportable.API.DTOs
{
  public class StartDeliverUsageEventDTO
  {
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("userId")]
    public string Email { get; set; }
    
    [JsonPropertyName("usageType")]
    public string UsageType { get; set; }
  }
}
