using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IStartDeliverService
  {
    List<StartDeliverUserSyncDTO> GetUsersToSync(int limit, int offset);
  }
}
