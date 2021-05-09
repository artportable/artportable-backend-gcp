using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IDiscoverService
  {
    List<ArtistDTO> GetArtists(string myUsername);
  }
}
