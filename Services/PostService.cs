using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Services
{
    public class PostService : IPostService
    {
        private readonly APContext _context;
        private readonly IMapper _mapper;

        public PostService(APContext apContext, IMapper mapper)
        {
            _context = apContext ?? throw new ArgumentNullException(nameof(apContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(p => p.User)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
        }

        public Post GetPostById(int id)
        {
            return _context.Posts
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == id);
        }

        public Post CreatePost(int userId, Post post)
{
    var user = _context.Users.FirstOrDefault(u => u.Id == userId);

    if (user == null)
    {
        throw new ArgumentException("User not found");
    }

    post.User = user;
    post.CreatedAt = DateTime.Now;

    _context.Posts.Add(post);
    _context.SaveChanges();


    return _context.Posts.Include(p => p.User).Include(p => p.Likes).Single(p => p.Id == post.Id);
}

        public void UpdatePost(Post updatedPost)
        {
            var post = _context.Posts
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == updatedPost.Id);

            if (post == null)
            {
                throw new ArgumentException("Post not found");
            }

            post.Content = updatedPost.Content;

            _context.Update(post);
            _context.SaveChanges();
        }

        public void DeletePost(Post postToDelete)
        {
            var post = _context.Posts
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == postToDelete.Id);

            if (post == null)
            {
                throw new ArgumentException("Post not found");
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
