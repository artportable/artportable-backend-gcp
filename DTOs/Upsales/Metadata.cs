using System.Text.Json.Serialization;

namespace Artportable.API.DTOs.Upsales
{
  public class Metadata
  {
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("offset")]
    public int Offset { get; set; }
  }
}