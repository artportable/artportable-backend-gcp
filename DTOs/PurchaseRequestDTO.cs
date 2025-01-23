using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Artportable.API.DTOs
{
    public class PurchaseRequestDTO
    {
        [JsonPropertyName("paymentMethodId")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("customer")]
        public StripeCustomerDTO Customer { get; set; }

        [JsonPropertyName("products")]
        public List<string> Products { get; set; }

        [JsonPropertyName("promotionCodeId")]
        public string PromotionCodeId { get; set; } = null;
    }
}
