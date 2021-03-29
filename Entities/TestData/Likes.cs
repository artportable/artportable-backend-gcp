using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Like[] Likes
    {
      get =>
        new Like[]
        {
          new Like
          {
            Id = 1,
            UserId = 1,
            ArtworkId = 2
          },
          new Like
          {
            Id = 2,
            UserId = 2,
            ArtworkId = 1
          },
          new Like
          {
            Id = 3,
            UserId = 1,
            ArtworkId = 3
          },
          new Like
          {
            Id = 4,
            UserId = 4,
            ArtworkId = 6
          },
          new Like
          {
            Id = 5,
            UserId = 5,
            ArtworkId = 4
          },
          new Like
          {
            Id = 6,
            UserId = 5,
            ArtworkId = 4
          }
        };
    }
  }
}
