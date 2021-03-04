using System.Text.Json.Serialization;
using Artportable.API.Enums;

namespace Artportable.API.DTOs
{
  public class PaymentIntentRequestDTO
  {
    [JsonPropertyName("subscription")]
    public SubscriptionEnum Subscription { get; set; }
  }
}
