using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IDiscoverService
  {
    List<ArtworkDTO> GetArtworks(int page, int pageNumber, string myUsername);
    List<ArtistDTO> GetArtists(string myUsername);
  }
}
