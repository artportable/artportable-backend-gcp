using System.Collections.Generic;
using System;
using Artportable.API.Entities.Models;

namespace Artportable.API.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikeCount { get; set; }

        // In PostDto class
        public static PostDto FromPost(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                UserId = post.UserId,
                UserName = post.User.Username,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                LikeCount = post.Likes.Count
            };
        }
    }
}
