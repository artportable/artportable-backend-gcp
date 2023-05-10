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
        public IEnumerable<PostDto> GetPosts()
        {
            return _postService.GetAllPosts().Select(PostDto.FromPost);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<PostDto> GetPost(int id)
        {
            var post = _postService.GetPostById(id);

            if (post == null)
            {
                return NotFound();
            }

            return PostDto.FromPost(post);
        }

        // POST: api/Posts
       [HttpPost]
       public ActionResult<PostDto> CreatePost(int userId, PostForCreationDto postForCreation)
        {
            var post = new Post
        {
            UserId = userId,
            Content = postForCreation.Content,
            CreatedAt = DateTime.UtcNow
        };
            var createdPost = _postService.CreatePost(userId, post); // This should return the newly created post with all properties initialized
            
            return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, PostDto.FromPost(createdPost));
        }




        // PUT: api/Posts/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdatePost(int id, PostForUpdateDto postForUpdate)
        {
            var post = _postService.GetPostById(id);

            if (post == null)
            {
                return NotFound();
            }

            post.Content = postForUpdate.Content;
            _postService.UpdatePost(post);
            return NoContent();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeletePost(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            _postService.DeletePost(post);
            return NoContent();
        }
    }
}
