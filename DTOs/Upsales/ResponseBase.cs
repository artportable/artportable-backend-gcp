using System.Text.Json.Serialization;

namespace Artportable.API.DTOs.Upsales
{
  public class ResponseBase<T>
  {
    [JsonPropertyName("error")]
    public Error Error { get; set; }
    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }
    [JsonPropertyName("data")]
    public T Data { get; set; }
  }
}