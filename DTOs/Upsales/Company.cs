using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Artportable.API.DTOs.Upsales
{
  public class Company
  {
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("fax")]
    public string Fax { get; set; }

    [JsonPropertyName("webpage")]
    public string Webpage { get; set; }
  }
}