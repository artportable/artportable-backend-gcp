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
    if (post == null)
    {
        throw new ArgumentNullException(nameof(post));
    }
    
    return new PostDto
    {
        Id = post.Id,
        UserId = post.UserId,
        UserName = post.User?.Username, // Use the null-conditional operator to avoid NullReferenceException
        Content = post.Content,
        CreatedAt = post.CreatedAt,
        LikeCount = post.Likes?.Count ?? 0 // Again, use the null-conditional operator. If Likes is null, default to 0.
    };
}
    }
}