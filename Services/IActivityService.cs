using System;
using System.Threading.Tasks;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IActivityService
  {
    TokenDTO ConnectUser(string username);
    Task Follow(string follower, string followee);
    Task UnFollow(string follower, string followee);
    Task LikeArtwork(Guid id, string myUsername, string owner);
    Task UnLikeArtwork(Guid id, string myUsername, string owner);
    Task CreateArtwork(Guid id, string title, string myUsername);
    Task UpdateArtwork(Guid id, string title, string myUsername);

  }
}
