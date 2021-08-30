using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IActivityService
  {
    TokenDTO ConnectUser(string username);
    void CreateActivity();
    FeedDTO GetFeed(string username);
    void Follow(string username);
  }
}
