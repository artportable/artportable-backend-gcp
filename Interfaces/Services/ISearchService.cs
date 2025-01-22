using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Enums;

namespace Artportable.API.Interfaces.Services
{
    public interface ISearchService
    {
        List<ArtworkDTO> SearchArtworks(
            int page,
            int pageSize,
            string myUsername,
            string q,
            List<string> tags,
            ProductEnum minimumProduct = ProductEnum.Portfolio
        );
        List<ArtistDTO> SearchArtists(
            int page,
            int pageSize,
            string myUsername,
            string q,
            int minArtworks = 1,
            ProductEnum minimumProduct = ProductEnum.Portfolio
        );
        List<ArtistDTO> SearchMonthlyArtists(int page, int pageSize, string myUsername, string q);
    }
}
