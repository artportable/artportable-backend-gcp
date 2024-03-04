using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Enums;

namespace Artportable.API.Services
{
  public interface IDiscoverService
  {
    List<ArtworkDTO> GetArtworks(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetArtworksSold(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetTopArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetTopArtworksSold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetTopArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetTrendingArtworks(int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, string orientation = null, string sizeFilter = null, string priceFilter = null,   ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetLatestArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetLatestArtworksSold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetLatestArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetLikedByMeArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetLikedArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetLikedByMeArtworksSold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetLikedByMeArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetTrendingArtworksSold(int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetTrendingArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, DateTime likesSince, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetCuratedArtworks(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetCuratedArtworksSold(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetCuratedArtworksUnsold(int page, int pageSize, List<string> tags, string myUsername, int seed, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtistDTO> GetArtists(int page, int pageSize, string myUsername, int seed, int minArtworks = 1, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtistDTO> GetTopArtists(int page, int pageSize, string myUsername, int minArtworks = 1, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtistDTO> GetMonthlyArtists(int page, int pageSize, string myUsername, int seed, int minArtworks = 1, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<ArtworkDTO> GetPromotedArtworks(int page, int pageSize, List<string> tags, string myUsername, ProductEnum minimumProduct = ProductEnum.Portfolio);
  }
}
