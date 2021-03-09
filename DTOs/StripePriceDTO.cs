using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Artportable.API.DTOs
{
  public class StripePriceDTO
  {
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
    [JsonPropertyName("recurringInterval")]
    public string RecurringInterval { get; set; }
    [JsonPropertyName("product")]
    public string Product { get; set; }
  }
}
