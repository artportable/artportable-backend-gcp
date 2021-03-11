namespace Artportable.API.DTOs
{
  public class PromotionDTO
  {
    public string Name { get; set; }

    public bool DiscountInPercent { get; set; }
    public decimal AmountOff { get; set; }
    public string Currency { get; set; }
  }
}
