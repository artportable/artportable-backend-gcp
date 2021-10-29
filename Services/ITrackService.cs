using Artportable.API.Enums;

namespace Artportable.API.Services
{
  public interface ITrackService
  {
    void TrackEvent(UsageEvent usageEvent, string userEmail);
  }
}
