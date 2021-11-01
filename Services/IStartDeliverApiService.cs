using System.Threading.Tasks;

namespace Artportable.API.Services
{
  public interface IStartDeliverApiService
  {
    Task TrackAppOpenedEvent(string userEmail);
  }
}
