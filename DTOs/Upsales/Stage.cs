using System.Text.Json.Serialization;

namespace Artportable.API.DTOs.Upsales
{
  public class Stage
  {
    [JsonPropertyName("id")]
    public int Id { get; set; }
  }
}