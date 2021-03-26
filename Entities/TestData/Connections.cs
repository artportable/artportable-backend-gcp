using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {

    private Connection[] getConnections() {
      var length = ConnectionList.GetLength(0);
      var connections = new Connection[length];

      for (int i = 0; i < length; i++) {
          connections[i] = new Connection() {
            Id = i+1,
            FollowerId = ConnectionList[i, 0],
            FolloweeId = ConnectionList[i, 1]
          };
      }

      return connections;
    }

    public Connection[] Connections
    {
      get => getConnections();
    }

    private int[,] ConnectionList = {
      {1, 2}, {1, 3}, {1, 4}, {1, 5}, {1, 8}, {1, 12}, {1, 15},
      {2, 1}, {2, 3}, {2, 4}, {2, 5}, {2, 8}, {2, 13}, {2, 16},
      {3, 1}, {3, 5}, {3, 7}, {3, 8}, {3, 9}, {3, 11}, {3, 13},
      {4, 1}, {4, 2}, {4, 3}, {4, 5}, {4, 7}, {4, 8}, {4, 9}, {4, 10}, {4, 11}, {4, 12}, {4, 13},
      {5, 2}, {5, 3}, {5, 4}, {5, 7}, {5, 8}, {5, 12}, {5, 13},
      {6, 1}, {6, 8}, {6, 9},
      {7, 1}, {7, 2}, {7, 8}, {7, 12}, {7, 13}, {7, 15}, {7, 16},
      {8, 4}, {8, 7}, {8, 10}, {8, 12},
      {10, 2}, {10, 3}, {10, 5}, {10, 8}, {10, 11}, {10, 12}, {10, 13},
      {11, 1}, {11, 5}, {11, 8}, {11, 12},
      {12, 2}, {12, 4}, {12, 11},
      {13, 1}, {13, 7}, {13, 8}, {13, 12}, {13, 16},
      {14, 15},
      {15, 14},
      {16, 3}, {16, 8}, {16, 10},
    };
  }
}
