 using System.Collections.Generic;
using Artportable.API.Entities.Models;

namespace Artportable.API.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int id);
        Post CreatePost(int userId, Post post); 
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}