namespace Artportable.API.Model
{
  public class  Auth
  {
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
  }
}