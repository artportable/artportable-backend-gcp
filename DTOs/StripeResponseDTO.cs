using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Artportable.API.DTOs
{
  public class StripeResponseDTO
  {
    [Required]
    [JsonPropertyName("id")]
    public string Id { get; set; }
  }
}
