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

        public IEnumerable<Post> GetAllPosts(int userId)
        {
            return _context.Posts
                .Include(p => p.User)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
        }

        public Post GetPostById(int id, int userId)
        {
            return _context.Posts
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == id && p.UserId == userId);
        }

        public void CreatePost(int userId, Post post)
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
        }

        public void UpdatePost(Post updatedPost, int userId)
        {
            var post = _context.Posts
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == updatedPost.Id && p.UserId == userId);

            if (post == null)
            {
                throw new ArgumentException("Post not found");
            }

            post.Content = updatedPost.Content;

            _context.Update(post);
            _context.SaveChanges();
        }

        public void DeletePost(Post postToDelete, int userId)
        {
            var post = _context.Posts
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == postToDelete.Id && p.UserId == userId);

            if (post == null)
            {
                throw new ArgumentException("Post not found");
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
