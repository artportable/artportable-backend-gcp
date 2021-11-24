using System.Text.Json.Serialization;

namespace Artportable.API.DTOs.Upsales
{
  public class OrderRow
  {
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("listPrice")]
    public decimal ListPrice { get; set; }

    [JsonPropertyName("purchaseCost")]
    public decimal PurchaseCost { get; set; }

    [JsonPropertyName("product")]
    public Product Product { get; set; }
  }
}