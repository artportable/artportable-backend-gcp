using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Extentions;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService _storyServcie;
        public StoriesController(IStoryService storyService)
            => _storyServcie = storyService;

        [HttpGet("")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StoryDTO>))]
        public ActionResult<List<StoryDTO>> Get(string owner = null, string myUsername = null)
        {
            try
            {
                var stories = _storyServcie.Get(owner, myUsername);

                return Ok(stories);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StoryDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public ActionResult<StoryDTO> GetStory(Guid id, string myUsername = null)
        {
            try
            {
                var story = _storyServcie.Get(id, myUsername);

                if (story == null)
                {
                    return NotFound();
                }

                return Ok(story);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("story/{slug}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StoryDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public ActionResult<StoryDTO> GetStoryBySlug(string slug, string myUsername = null)
        {
            try 
            {
                var story = _storyServcie.GetBySlug(slug, myUsername);

                if (story == null)
                {
                    return NotFound();
                }

                return Ok(story);
            }
            catch (Exception e)
            {
            

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [Authorize]
        [HttpPost("")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StoryDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public ActionResult<StoryDTO> CreateStory([FromBody] StoryForCreationDTO dto, Guid mySocialId)
        {
            try
            {

                var story = _storyServcie.Create(dto, mySocialId);

                if (story == null)
                {
                    return BadRequest();
                }

                return Ok(story);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StoryDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public ActionResult<ArtworkDTO> UpdateStory([FromBody] StoryForUpdateDTO dto, Guid id, Guid mySocialId)
        {
            try
            {
                var story = _storyServcie.Update(dto, id, mySocialId);

                if (story == null)
                {
                    return NotFound();
                }

                return Ok(story);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public IActionResult DeleteStory(Guid id, string myUsername = null)
        {
            try
            {
                _storyServcie.Delete(id, myUsername);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("latest", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StoryDTO>))]
        public ActionResult<List<StoryDTO>> GetLatestStories(int page = 1, int pageSize = 10)
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
                var stories = new List<StoryDTO>();
                stories = _storyServcie.GetLatestStories(page, pageSize);

                var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { }, page, pageSize, stories.Count);
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

        [HttpGet("userExhibitions", Name = "[controller]_[action]")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<StoryDTO>))]
        public ActionResult<List<StoryDTO>> GetUserExhibitions(int page = 1, int pageSize = 10)
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
                var stories = new List<StoryDTO>();
                stories = _storyServcie.GetUserExhibitions(page, pageSize);

                var links = Url.ToPageLinks(ControllerContext.RouteData.ToRouteName(), new { }, page, pageSize, stories.Count);
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
    }
}
