using Artportable.API.DTOs;
using System.Threading.Tasks;

namespace Artportable.API.Services
{
  public interface IMessageService
  {
    TokenDTO ConnectUser(string username);
    void PurchaseRequest(string email, string message, string artworkUrl, string artworkName, string artistId);
    void SyncUser(string username, string role);
    void SyncChannel(string username, string role);
  }
}
