using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IDiscoverService
  {
    List<ArtworkDTO> GetArtworks(int page, int pageSize, List<string> tags, string myUsername);
    List<ArtistDTO> GetArtists(int page, int pageSize, string q, string myUsername);
  }
}
