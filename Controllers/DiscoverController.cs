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
                    artworks = _discoverService.GetArtworks(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        seed.Value
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetArtworksSold(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        seed.Value
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetArtworksUnsold(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        seed.Value
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetTopArtworksSold(
                        page,
                        pageSize,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetTopArtworksUnsold(
                        page,
                        pageSize,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
            string q = null,
            string orientation = null,
            string sizeFilter = null,
            string priceFilter = null
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
                    artworks = _discoverService.GetTrendingArtworks(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        DateTime.Now.AddDays(likesSince),
                        orientation,
                        sizeFilter,
                        priceFilter
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
        /// Get a collection of art ordered by date added
        /// </summary>
        [HttpGet("artworks/latest", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetLatestArtworks(
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
                    artworks = _discoverService.GetLatestArtworks(page, pageSize, tags, myUsername);
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
        /// Get a collection of art ordered by digital
        /// </summary>
        [HttpGet("artworks/digital", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetDigitalArtworks(
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
                    artworks = _discoverService.GetDigitalArtworks(
                        page,
                        pageSize,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
        /// Get a collection of art ordered by date added
        /// </summary>
        [HttpGet("artworks/latestsold", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetLatestArtworksSold(
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
                    artworks = _discoverService.GetLatestArtworksSold(
                        page,
                        pageSize,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
        /// Get a collection of art ordered by date added
        /// </summary>
        [HttpGet("artworks/latestunsold", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetLatestArtworksUnsold(
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
                    artworks = _discoverService.GetLatestArtworksUnsold(
                        page,
                        pageSize,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetLikedByMeArtworks(
                        page,
                        pageSize,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
        /// Get a collection of art liked by user, exclude own artworks
        /// </summary>
        [HttpGet("artworks/likedart", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetLikedArtworks(
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
                    artworks = _discoverService.GetLikedArtworks(page, pageSize, tags, myUsername);
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetLikedByMeArtworksSold(
                        page,
                        pageSize,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetLikedByMeArtworksUnsold(
                        page,
                        pageSize,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetTrendingArtworksSold(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        DateTime.Now.AddDays(likesSince)
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
                    artworks = _discoverService.GetTrendingArtworksUnsold(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        DateTime.Now.AddDays(likesSince)
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
        public ActionResult<List<ArtistDTO>> GetArtists(
            int page = 1,
            int pageSize = 10,
            string q = null,
            string myUsername = null,
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

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        q = urlEncodedQuery,
                        myUsername = myUsername,
                    },
                    page,
                    pageSize,
                    artists.Count
                );
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
        public ActionResult<List<ArtistDTO>> GetTopArtists(
            int page = 1,
            int pageSize = 10,
            string q = null,
            string myUsername = null
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

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new { q = urlEncodedQuery, myUsername = myUsername },
                    page,
                    pageSize,
                    artists.Count
                );
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
        public ActionResult<List<ArtistDTO>> GetMonthlyArtists(
            int page = 1,
            int pageSize = 10,
            string q = null,
            string myUsername = null,
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
                var artists = new List<ArtistDTO>();

                if (string.IsNullOrWhiteSpace(q))
                {
                    artists = _discoverService.GetMonthlyArtists(
                        page,
                        pageSize,
                        myUsername,
                        seed.Value
                    );
                }
                else
                {
                    artists = _searchService.SearchMonthlyArtists(page, pageSize, myUsername, q);
                }
                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        q = urlEncodedQuery,
                        myUsername = myUsername,
                    },
                    page,
                    pageSize,
                    artists.Count
                );
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
                    artworks = _discoverService.GetCuratedArtworks(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        seed.Value
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
        /// Get a collection of art curated by user 10
        /// </summary>
        [HttpGet("artworks/curatedsold", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetCuratedArtworksSold(
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
                    artworks = _discoverService.GetCuratedArtworksSold(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        seed.Value
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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

        /// <summary> Unsold
        /// Get a collection of art curated by user 10
        /// </summary>
        [HttpGet("artworks/curatedunsold", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetCuratedArtworksUnsold(
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
                    artworks = _discoverService.GetCuratedArtworksUnsold(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        seed.Value
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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
        /// Get a collection of art curated by user 11
        /// </summary>
        [HttpGet("artworks/selected", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetSelectedArtworks(
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
                    artworks = _discoverService.GetArtportableSelection(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        seed.Value
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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

        /// <summary> PROMOTED
        /// Get a collection of art
        /// </summary>
        [HttpGet("artworks/promoted", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetPromotedArtworks(
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
                    artworks = _discoverService.GetPromotedArtworks(
                        page,
                        pageSize,
                        seed.Value,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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

        /// <summary> PROMOTED
        /// Get a collection of art
        /// </summary>
        [HttpGet("artworks/isAaf", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetisAafArtworks(
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
                    artworks = _discoverService.GetAafArtworks(
                        page,
                        pageSize,
                        seed.Value,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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

        /// <summary> Boosted
        /// Get a collection of boosted art
        /// </summary>
        [HttpGet("artworks/boosted", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetBoostedArtworks(
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
                    artworks = _discoverService.GetBoostedArtworks(
                        page,
                        pageSize,
                        seed.Value,
                        tags,
                        myUsername
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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

        /// <summary> Boosted
        /// Get a collection of boosted art
        /// </summary>
        [HttpGet("stories/boosted", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StoryDTO>))]
        public ActionResult<List<StoryDTO>> GetBoostedStories(
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
                var stories = new List<StoryDTO>();

                stories = _discoverService.GetBoostedStories(
                    page,
                    pageSize,
                    seed.Value,
                    myUsername
                );

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        seed = seed,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    stories.Count
                );
                Response.Headers.Add("Access-Control-Expose-Headers", "Link");
                Response.Headers.Add("Link", string.Join(", ", links));

                return Ok(stories);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary> ALL
        /// Get a collection of art by filter
        /// </summary>
        [HttpGet("artworks/filter", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ArtworkDTO>))]
        public ActionResult<List<ArtworkDTO>> GetFilteredArtworks(
            [FromQuery(Name = "tag")] List<string> tags,
            int page = 1,
            int pageSize = 10,
            string myUsername = null,
            int likesSince = -14,
            string q = null,
            string orientation = null,
            string sizeFilter = null,
            string priceFilter = null,
            decimal? minHeight = null,
            decimal? maxHeight = null,
            decimal? minWidth = null,
            decimal? maxWidth = null,
            string? stateFilter = null,
            string? orderBy = null
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
                    artworks = _discoverService.GetFilteredArtworks(
                        page,
                        pageSize,
                        tags,
                        myUsername,
                        DateTime.Now.AddDays(likesSince),
                        orientation,
                        sizeFilter,
                        priceFilter,
                        minHeight,
                        maxHeight,
                        minWidth,
                        maxWidth,
                        stateFilter,
                        orderBy
                    );
                }
                else
                {
                    artworks = _searchService.SearchArtworks(page, pageSize, myUsername, q, tags);
                }

                string urlEncodedQuery = System.Net.WebUtility.UrlEncode(q);

                var links = Url.ToPageLinks(
                    ControllerContext.RouteData.ToRouteName(),
                    new
                    {
                        tag = tags,
                        myUsername = myUsername,
                        q = urlEncodedQuery,
                    },
                    page,
                    pageSize,
                    artworks.Count
                );
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