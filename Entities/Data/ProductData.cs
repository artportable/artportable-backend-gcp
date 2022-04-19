using Artportable.API.Entities.Models;

namespace Artportable.API.SeedData
{
  public partial class ProductData
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
          },
          new Product
          {
            Id = 4,
            Name = "Staff"
          },
           new Product
          {
            Id = 10,
            Name = "Staff"
          }
        };
    }
  }
}
