using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Extentions;
using Artportable.API.Interfaces.Services;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DiscoverController : ControllerBase
  {
    private readonly IDiscoverService _discoverService;
    private readonly ISearchService _searchService;
    private readonly Random _random;

    public DiscoverController(IDiscoverService discoverService, ISearchService searchService)
    {
      _discoverService = discoverService;
      _searchService = searchService;
      _random = new Random();
    }

    #region Artworks
    /// <summary>
    /// Get a collection of art
    /// </summary>
    [HttpGet("artworks", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetArtworks(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      string q = null,
      int? seed = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      if (!seed.HasValue && string.IsNullOrWhiteSpace(q))
      {
        seed = _random.Next();
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetArtworks(page, pageSize, tags, myUsername, seed.Value);
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { seed = seed, tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> SOLD
    /// Get a collection of art
    /// </summary>
    [HttpGet("artworks/sold", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetArtworksSold(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      string q = null,
      int? seed = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      if (!seed.HasValue && string.IsNullOrWhiteSpace(q))
      {
        seed = _random.Next();
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetArtworksSold(page, pageSize, tags, myUsername, seed.Value);
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { seed = seed, tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> UNSOLD
    /// Get a collection of art
    /// </summary>
    [HttpGet("artworks/unsold", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetArtworksUnsold(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      string q = null,
      int? seed = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      if (!seed.HasValue && string.IsNullOrWhiteSpace(q))
      {
        seed = _random.Next();
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetArtworksUnsold(page, pageSize, tags, myUsername, seed.Value);
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { seed = seed, tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> 
    /// Get a collection of art ordered by most likes
    /// </summary>
    [HttpGet("artworks/top", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetTopArtworks(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetTopArtworks(page, pageSize, tags, myUsername);
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> SOLD
    /// Get a collection of art ordered by most likes
    /// </summary>
    [HttpGet("artworks/topsold", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetTopArtworksSold(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetTopArtworksSold(page, pageSize, tags, myUsername);
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> UNSOLD
    /// Get a collection of art ordered by most likes
    /// </summary>
    [HttpGet("artworks/topunsold", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetTopArtworksUnsold(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetTopArtworksUnsold(page, pageSize, tags, myUsername);
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> ALL
    /// Get a collection of art ordered by most likes since date
    /// </summary>
    [HttpGet("artworks/trending", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetTrendingArtworks(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      int likesSince = -14,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetTrendingArtworks(page, pageSize, tags, myUsername, DateTime.Now.AddDays(likesSince));
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> ALL
    /// Get a collection of art liked by user
    /// </summary>
    [HttpGet("artworks/likedbyme", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetLikedByMeArtworks(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      int likesSince = -14,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetLikedByMeArtworks(page, pageSize, tags, myUsername, DateTime.Now.AddDays(likesSince));
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> Sold
    /// Get a collection of art liked by user
    /// </summary>
    [HttpGet("artworks/likedbymesold", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetLikedByMeArtworksSold(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      int likesSince = -14,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetLikedByMeArtworksSold(page, pageSize, tags, myUsername, DateTime.Now.AddDays(likesSince));
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> ALL
    /// Get a collection of art liked by user
    /// </summary>
    [HttpGet("artworks/likedbymeunsold", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetLikedByMeArtworksUnsold(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      int likesSince = -14,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetLikedByMeArtworksUnsold(page, pageSize, tags, myUsername, DateTime.Now.AddDays(likesSince));
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }



    /// <summary> SOLD
    /// Get a collection of art ordered by most likes since date 
    /// </summary>
    [HttpGet("artworks/trendingsold", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetTrendingArtworksSold(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      int likesSince = -14,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetTrendingArtworksSold(page, pageSize, tags, myUsername, DateTime.Now.AddDays(likesSince));
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary> UNSOLD
    /// Get a collection of art ordered by most likes since date
    /// </summary>
    [HttpGet("artworks/trendingunsold", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetTrendingArtworksUnsold(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      int likesSince = -14,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetTrendingArtworksUnsold(page, pageSize, tags, myUsername, DateTime.Now.AddDays(likesSince));
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    #endregion

    #region Artists

    /// <summary>
    /// Get a collection of artists
    /// </summary>
    [HttpGet("artists", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtistDTO>))]
    public ActionResult<List<ArtistDTO>> GetArtists(int page = 1, int pageSize = 10, string q = null, string myUsername = null, int? seed = null)
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      if (!seed.HasValue && string.IsNullOrWhiteSpace(q))
      {
        seed = _random.Next();
      }

      try
      {

        var artists = new List<ArtistDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artists = _discoverService.GetArtists(page, pageSize, myUsername, seed.Value);
        }
        else
        {
          artists = _searchService.SearchArtists(page, pageSize, myUsername, q);
        }
        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { seed = seed, q = urlEncodedQuery, myUsername = myUsername }, page, pageSize, artists.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artists);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Get a collection of artists ordered by most followers
    /// </summary>
    [HttpGet("artists/top", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtistDTO>))]
    public ActionResult<List<ArtistDTO>> GetTopArtists(int page = 1, int pageSize = 10, string q = null, string myUsername = null)
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {

        var artists = new List<ArtistDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artists = _discoverService.GetTopArtists(page, pageSize, myUsername);
        }
        else
        {
          artists = _searchService.SearchArtists(page, pageSize, myUsername, q);
        }
        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { q = urlEncodedQuery, myUsername = myUsername }, page, pageSize, artists.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artists);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// <summary>
    /// Get a collection of monthly artists
    /// </summary>
    [HttpGet("monthlyArtists", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtistDTO>))]
    public ActionResult<List<ArtistDTO>> GetMonthlyArtists(int page = 1, int pageSize = 10, string q = null, string myUsername = null, int? seed = null)
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      if (!seed.HasValue && string.IsNullOrWhiteSpace(q))
      {
        seed = _random.Next();
      }


      try
      {
        var artists = new List<ArtistDTO>();

        if (string.IsNullOrWhiteSpace(q))
        {
          artists = _discoverService.GetMonthlyArtists(page, pageSize, myUsername, seed.Value);
        }
        else
        {
          artists = _searchService.SearchMonthlyArtists(page, pageSize, myUsername, q);
        }
        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { seed = seed, q = urlEncodedQuery, myUsername = myUsername }, page, pageSize, artists.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artists);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }


    /// <summary> ALL
    /// Get a collection of art curated by user 10
    /// </summary>
    [HttpGet("artworks/curated", Name = "[controller]_[action]")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
    public ActionResult<List<ArtworkDTO>> GetCuratedArtworks(
      [FromQuery(Name = "tag")] List<string> tags,
      int page = 1,
      int pageSize = 10,
      string myUsername = null,
      string q = null
    )
    {
      if (page < 1 || pageSize < 1)
      {
        return BadRequest();
      }

      if (pageSize > 1000)
      {
        pageSize = 1000;
      }

      try
      {
        var artworks = new List<ArtworkDTO>();
        if (string.IsNullOrWhiteSpace(q))
        {
          artworks = _discoverService.GetCuratedArtworks(page, pageSize, tags, myUsername);
        }
        else
        {
          artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
        }

        string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

        var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { tag = tags, myUsername = myUsername, q = urlEncodedQuery }, page, pageSize, artworks.Count);
        Response.Headers.Add("Access-Control-Expose-Headers", "Link");
        Response.Headers.Add("Link", string.Join(", ", links));

        return Ok(artworks);
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
  #endregion
}
