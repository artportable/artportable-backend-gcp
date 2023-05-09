using System.Collections.Generic;
using Artportable.API.Entities.Models;

namespace Artportable.API.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts(int userId);
        Post GetPostById(int id, int userId);
        void CreatePost(int userId, Post post);
        void UpdatePost(Post post, int userId);
        void DeletePost(Post post, int userId);
    }
}
