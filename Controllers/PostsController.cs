using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Artportable.API.Entities.Models;
using Artportable.API.Services;
using Artportable.API.DTOs;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Artportable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<PostDto> GetPosts(Guid mySocialId)
        {
            int userId = GetUserIdBySocialId(mySocialId);
            return _postService.GetAllPosts(userId).Select(PostDto.FromPost);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<PostDto> GetPost(int id, Guid mySocialId)
        {
            int userId = GetUserIdBySocialId(mySocialId);
            var post = _postService.GetPostById(id, userId);

            if (post == null)
            {
                return NotFound();
            }

            return PostDto.FromPost(post);
        }

        // POST: api/Posts
        [Authorize]
        [HttpPost]
        public ActionResult<PostDto> CreatePost([FromBody] PostForCreationDto postForCreation, Guid mySocialId)
        {
            int userId = GetUserIdBySocialId(mySocialId);
            var post = new Post
            {
                UserId = userId,
                Content = postForCreation.Content,
                CreatedAt = DateTime.UtcNow
            };
            _postService.CreatePost(userId, post);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, PostDto.FromPost(post));
        }

        // PUT: api/Posts/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, PostForUpdateDto postForUpdate, Guid mySocialId)
        {
            int userId = GetUserIdBySocialId(mySocialId);
            var post = _postService.GetPostById(id, userId);

            if (post == null)
            {
                return NotFound();
            }

            post.Content = postForUpdate.Content;
            _postService.UpdatePost(post, userId);
            return NoContent();
        }

        // DELETE: api/Posts/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id, Guid mySocialId)
        {
            int userId = GetUserIdBySocialId(mySocialId);
            var post = _postService.GetPostById(id, userId);
            if (post == null)
            {
                return NotFound();
            }

            _postService.DeletePost(post, userId);
            return NoContent();
        }

        // Replace this line with a method that retrieves the user ID based on the mySocialId
        private int GetUserIdBySocialId(Guid mySocialId)
        {
            // Implement the logic to get the userId from mySocialId
            throw new NotImplementedException();
        }
    }
}
