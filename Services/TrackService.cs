using Artportable.API.Entities;
using Artportable.API.Enums;
using System;
using System.Net.Http;

namespace Artportable.API.Services
{
  public class TrackService : ITrackService
  {
    private readonly IStartDeliverApiService _startDeliverApiService;

    public TrackService(IStartDeliverApiService startDeliverApiService)
    {
      _startDeliverApiService = startDeliverApiService;
    }

    public void TrackEvent(UsageEvent usageEvent, string userEmail)
    {
      switch (usageEvent)
      {
          case UsageEvent.OpenedApp:
            _startDeliverApiService.TrackAppOpenedEvent(userEmail);
            break;
          default:
            throw new Exception("Unknown usage event");
      }
    }
  }
}
