namespace Artportable.API.DTOs
{
  public class StripeSubscriptionResponseDTO
  {
    public string Status { get; set; }
    public string Id { get; set; }
    public string ClientSecret { get; set; }
  }
}
