using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Artportable.API.DTOs.Upsales
{
  public class Order
  {
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; set; }

    [JsonPropertyName("user")]
    public User User { get; set; }

    [JsonPropertyName("client")]
    public Company Client { get; set; }

    [JsonPropertyName("stage")]
    public Stage Stage { get; set; }

    [JsonPropertyName("probability")]
    public int Probability { get; set; }

    [JsonPropertyName("orderRow")]
    public List<OrderRow> OrderRow { get; set; }
  }
}