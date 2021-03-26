using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Connection[] Connections
    {
      get =>
        new Connection[]
        {
          new Connection
          {
            Id = 1,
            FollowerId = 1,
            FolloweeId = 2
          },
          new Connection
          {
            Id = 2,
            FollowerId = 2,
            FolloweeId = 1
          },
          new Connection
          {
            Id = 3,
            FollowerId = 1,
            FolloweeId = 3
          },
          new Connection
          {
            Id = 4,
            FollowerId = 3,
            FolloweeId = 6
          },
          new Connection
          {
            Id = 5,
            FollowerId = 3,
            FolloweeId = 4
          },
          new Connection
          {
            Id = 6,
            FollowerId = 2,
            FolloweeId = 4
          }
        };
    }
  }
}
