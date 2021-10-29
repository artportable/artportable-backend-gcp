using System.Threading.Tasks;

namespace Artportable.API.Services
{
  public interface IStartDeliverApiService
  {
    Task<string> TrackAppOpenedEvent(string userEmail);
  }
}
