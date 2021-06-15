using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IMessageService
  {
    TokenDTO ConnectUser(string username);
    void SyncUser(string username, string role);
    void SyncChannel(string username, string role);
  }
}
