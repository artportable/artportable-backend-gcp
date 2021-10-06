using System;
using System.Threading.Tasks;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IActivityService
  {
    TokenDTO ConnectUser(string username);
    Task Follow(Guid follower, Guid followee);
    Task UnFollow(Guid follower, Guid followee);
    Task LikeArtwork(Guid id, Guid myUsername, Guid owner);
    Task UnLikeArtwork(Guid id, Guid myUsername, Guid owner);
    Task CreateArtwork(Guid id, string title, Guid myUsername);
    Task UpdateArtwork(Guid id, string title, Guid myUsername);

  }
}
