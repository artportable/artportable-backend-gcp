﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Artportable.API.DTOs
{
  public class StripeCustomerDTO
  {
    [Required]
    [JsonPropertyName("email"), EmailAddress]
    public string Email { get; set; }
    [Required]
    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }
  }
}
