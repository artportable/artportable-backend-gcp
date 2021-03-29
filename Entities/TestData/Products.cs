using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Product[] Products
    {
      get =>
        new Product[]
        {
          new Product
          {
            Id = 1,
            Name = "Bas"
          },
          new Product
          {
            Id = 2,
            Name = "Portfolio"
          },
          new Product
          {
            Id = 3,
            Name = "Portfolio Premium"
          }
        };
    }
  }
}
