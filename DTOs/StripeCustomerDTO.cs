using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class StripeCustomerDTO
  {
    [Required]
    public string Email { get; set; }
    [Required]
    public string FullName { get; set; }
  }
}
