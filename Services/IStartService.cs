using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IStartService
  {
    List<UserImageDTO> Get();
  }
}
