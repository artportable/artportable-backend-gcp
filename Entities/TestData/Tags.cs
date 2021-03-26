using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Tag[] Tags
    {
      get =>
        new Tag[]
        {
          new Tag
          {
            Id = 1,
            Title = "oil"
          },
          new Tag
          {
            Id = 2,
            Title = "acrylic"
          },
          new Tag
          {
            Id = 3,
            Title = "forest"
          },
          new Tag
          {
            Id = 4,
            Title = "self-portrait"
          },
          new Tag
          {
            Id = 5,
            Title = "sea"
          },
          new Tag
          {
            Id = 6,
            Title = "fruit"
          }
        };
    }
  }
}
