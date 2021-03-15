using System.Text.Json.Serialization;

namespace Artportable.API.DTOs
{
  public class SubscriptionRequestDTO
  {
    [JsonPropertyName("paymentMethodId")]
    public string PaymentMethod { get; set; }

    [JsonPropertyName("customerId")]
    public string Customer { get; set; }

    [JsonPropertyName("priceId")]
    public string Price { get; set; }
    [JsonPropertyName("promotionCodeId")]
    public string PromotionCodeId { get; set; } = null;
  }
}
