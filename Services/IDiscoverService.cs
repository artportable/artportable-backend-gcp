using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Enums;

namespace Artportable.API.Services
{
  public interface IDiscoverService
  {
    List<ArtworkDTO> GetArtworks(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtistDTO> GetArtists(int page, int pageSize, string myUsername, int seed, int minArtworks = 1, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtistDTO> GetMonthlyArtists(int page, int pageSize, string myUsername, int seed);
  }
}
