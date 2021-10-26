using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IDiscoverService
  {
    List<ArtworkDTO> GetArtworks(int page, int pageSize, List<string> tags, string myUsername, string q, int seed);
    List<ArtistDTO> GetArtists(int page, int pageSize, string q, string myUsername, int seed);
    List<ArtistDTO> GetMonthlyArtists(int page, int pageSize, string q, string myUsername, int seed);
  }
}
