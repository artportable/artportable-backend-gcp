using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
using Artportable.API.Interfaces.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NinjaNye.SearchExtensions;

namespace Artportable.API.Services
{
    public class SearchService : ISearchService
    {
        private readonly APContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(15);

        public SearchService(APContext apContext, IMapper mapper, IMemoryCache cache)
        {
            _context = apContext ?? throw new ArgumentNullException(nameof(apContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        private string GenerateCacheKey(string q, int page, int pageSize, List<string> tags, ProductEnum minimumProduct)
        {
            var tagString = tags != null && tags.Any() ? string.Join(",", tags.OrderBy(t => t)) : "notags";
            return $"search_artworks_{q}_{page}_{pageSize}_{tagString}_{minimumProduct}";
        }

        public List<ArtworkDTO> SearchArtworks(
            int page,
            int pageSize,
            string myUsername,
            string q,
            List<string> tags,
            ProductEnum minimumProduct = ProductEnum.Portfolio
        )
        {
            var cacheKey = GenerateCacheKey(q, page, pageSize, tags, minimumProduct);
            
            // Try to get results from cache first
            if (_cache.TryGetValue<List<ArtworkDTO>>(cacheKey, out var cachedResults))
            {
                // Update LikedByMe status for cached results since it depends on the current user
                if (cachedResults != null)
                {
                    foreach (var artwork in cachedResults)
                    {
                        artwork.LikedByMe = !string.IsNullOrWhiteSpace(myUsername) && 
                            _context.Likes.Any(l => l.Artwork.PublicId == artwork.Id && l.User.Username == myUsername);
                    }
                    return cachedResults;
                }
            }

            IQueryable<Artwork> query = _context.Artworks;
            if (!string.IsNullOrWhiteSpace(q))
            {
                var terms = q.Split(' ').Select(t => t.Trim().ToLower()).Where(t => !string.IsNullOrEmpty(t)).ToArray();
                Console.WriteLine($"Search terms: {string.Join(", ", terms)}");

                // Get all tags that match any of the search terms
                var matchingTags = _context.Tags
                    .Where(t => terms.Any(term => 
                        t.Title.ToLower().Contains(term) || // Tag contains search term
                        term.Contains(t.Title.ToLower()) || // Search term contains tag
                        t.Title.ToLower() == term || // Exact match
                        t.Title.ToLower().Replace("-", "") == term || // Match without hyphens
                        term.Replace("-", "") == t.Title.ToLower() || // Match without hyphens
                        t.Title.ToLower() == "figurative" && (term == "figurativ" || term == "figurativt") || // Handle translations
                        t.Title.ToLower() == "sculpture" && (term == "skulptur" || term == "veistos") // Handle translations
                    ))
                    .Select(t => t.Title)
                    .ToList();

                Console.WriteLine($"Matching tags: {string.Join(", ", matchingTags)}");

                // First search in main fields with weights
                var titleMatches = query
                    .Search(a => a.Title)
                    .Containing(terms)
                    .ToRanked()
                    .Select(r => new { Item = r.Item, Score = r.Hits * 10.0 })
                    .ToList(); // Title matches have highest weight
                Console.WriteLine($"Title matches count: {titleMatches.Count}");

                var tagMatches = query
                    .Where(a => a.Tags.Any(t => matchingTags.Contains(t.Title)))
                    .Select(a => new { Item = a, Score = 8.0 })
                    .ToList(); // Tag matches have second highest weight
                Console.WriteLine($"Tag matches count: {tagMatches.Count}");

                var descriptionMatches = query
                    .Search(a => a.Description)
                    .Containing(terms)
                    .ToRanked()
                    .Select(r => new { Item = r.Item, Score = r.Hits * 5.0 })
                    .ToList(); // Description matches have medium weight
                Console.WriteLine($"Description matches count: {descriptionMatches.Count}");

                var userMatches = query
                    .Search(
                        a => a.User.Username,
                        a => a.User.UserProfile.Name,
                        a => a.User.UserProfile.Surname
                    )
                    .Containing(terms)
                    .ToRanked()
                    .Select(r => new { Item = r.Item, Score = r.Hits * 3.0 })
                    .ToList(); // User info matches have lowest weight
                Console.WriteLine($"User matches count: {userMatches.Count}");

                // Combine all matches and get the highest score for each artwork
                var combinedResults = titleMatches
                    .Union(tagMatches)
                    .Union(descriptionMatches)
                    .Union(userMatches)
                    .GroupBy(r => r.Item.Id)
                    .Select(g => new { 
                        Item = g.First().Item, 
                        Score = g.Max(r => r.Score) 
                    })
                    .OrderByDescending(r => r.Score)
                    .ToList();
                Console.WriteLine($"Combined results count: {combinedResults.Count}");

                query = combinedResults.Select(r => r.Item).AsQueryable();
            }
            
            // Handle additional tag filtering
            if (tags != null && tags.Any())
            {
                var normalizedTags = tags.Select(t => t.Trim().ToLower()).Where(t => !string.IsNullOrEmpty(t)).ToList();
                query = query.Where(a => a.Tags.Any(t => normalizedTags.Any(tag => 
                    t.Title.ToLower() == tag || // Exact match
                    t.Title.ToLower().Contains(tag) || // Tag contains search term
                    tag.Contains(t.Title.ToLower()) // Search term contains tag
                )));
            }

            var results = query
                .Where(a => a.User.Subscription.ProductId >= (int)minimumProduct)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Select(a => new ArtworkDTO
                {
                    Id = a.PublicId,
                    Owner = new OwnerDTO
                    {
                        Username = a.User.Username,
                        ProfilePicture = a.User.File.Name,
                        SocialId = a.User.SocialId,
                        Name = a.User.UserProfile.Name,
                        Surname = a.User.UserProfile.Surname,
                        Location = a.User.UserProfile.Location,
                    },
                    Title = a.Title,
                    Name = a.User.UserProfile.Name,
                    Surname = a.User.UserProfile.Surname,
                    Username = a.User.Username,
                    Description = a.Description,
                    Published = a.Published,
                    Price = a.Price,
                    Currency = a.Currency,
                    SoldOut = a.SoldOut,
                    MultipleSizes = a.MultipleSizes,
                    Width = a.Width,
                    Height = a.Height,
                    Depth = a.Depth,
                    PrimaryFile = new FileDTO
                    {
                        Name = a.PrimaryFile.Name,
                        Width = a.PrimaryFile.Width,
                        Height = a.PrimaryFile.Height,
                    },
                    SecondaryFile =
                        a.SecondaryFile != null
                            ? new FileDTO
                            {
                                Name = a.SecondaryFile.Name,
                                Width = a.SecondaryFile.Width,
                                Height = a.SecondaryFile.Height,
                            }
                            : null,
                    TertiaryFile =
                        a.TertiaryFile != null
                            ? new FileDTO
                            {
                                Name = a.TertiaryFile.Name,
                                Width = a.TertiaryFile.Width,
                                Height = a.TertiaryFile.Height,
                            }
                            : null,
                    Tags = (
                        a.Tags != null ? a.Tags.Select(t => t.Title).ToList() : new List<string>()
                    ),
                    Likes = a.Likes.Count(),
                    LikedByMe = !string.IsNullOrWhiteSpace(myUsername)
                        ? a.Likes.Any(l => l.User.Username == myUsername)
                        : false,
                })
                .ToList();

            // Cache the results
            _cache.Set(cacheKey, results, CacheDuration);

            return results;
        }

        public List<ArtistDTO> SearchArtists(
            int page,
            int pageSize,
            string myUsername,
            string q,
            int minArtworks = 1,
            ProductEnum minimumProduct = ProductEnum.Portfolio
        )
        {
            IQueryable<User> query = _context.Users;
            if (!string.IsNullOrWhiteSpace(q))
            {
                var terms = q.Split(' ');
                query = query
                    .Search(u => u.Username, u => u.UserProfile.Name, u => u.UserProfile.Surname)
                    .Containing(terms)
                    .ToRanked()
                    .OrderByDescending(r => r.Hits)
                    .Select(a => a.Item);
            }

            var artists = query
                .Include(u => u.UserProfile)
                .Include(u => u.File)
                .Include(u => u.Artworks)
                .ThenInclude(a => a.PrimaryFile)
                .Include(u => u.Artworks)
                .ThenInclude(a => a.Tags)
                .Include(u => u.Artworks)
                .ThenInclude(a => a.Likes)
                .Where(u => u.Artworks.Count() >= minArtworks)
                .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Select(u => new ArtistDTO
                {
                    Username = u.Username,
                    ProfilePicture = u.File.Name,
                    Location = u.UserProfile.Location,
                    Name = u.UserProfile.Name,
                    Surname = u.UserProfile.Surname,
                    Artworks = u
                        .Artworks.OrderBy(a => a.Likes.Count())
                        .Take(15)
                        .Select(a => new TinyArtworkDTO
                        {
                            Id = a.PublicId,
                            Title = a.Title,
                            PrimaryFile = new FileDTO
                            {
                                Name = a.PrimaryFile.Name,
                                Width = a.PrimaryFile.Width,
                                Height = a.PrimaryFile.Height,
                            },
                        })
                        .ToList(),
                    Tags = u.Artworks.SelectMany(a => a.Tags.Select(t => t.Title)).Take(5).ToList(),
                    FollowedByMe = !string.IsNullOrWhiteSpace(myUsername)
                        ? _context.Connections.Any(c =>
                            c.Followee.Username == u.Username && c.Follower.Username == myUsername
                        )
                        : false,
                    MonthlyArtist = u.MonthlyUser,
                })
                .ToList();

            return artists;
        }

        public List<ArtistDTO> SearchMonthlyArtists(
            int page,
            int pageSize,
            string myUsername,
            string q
        )
        {
            IQueryable<User> users = _context.Users;
            if (!string.IsNullOrWhiteSpace(q))
            {
                var terms = q.Split(' ');
                users = users
                    .Search(u => u.Username, u => u.UserProfile.Name, u => u.UserProfile.Surname)
                    .Containing(terms)
                    .ToRanked()
                    .OrderByDescending(r => r.Hits)
                    .Select(a => a.Item);
            }

            var artists = users
                .Include(u => u.UserProfile)
                .Include(u => u.File)
                .Include(u => u.Artworks)
                .ThenInclude(a => a.PrimaryFile)
                .Include(u => u.Artworks)
                .ThenInclude(a => a.Tags)
                .Include(u => u.Artworks)
                .ThenInclude(a => a.Likes)
                .Where(u => u.MonthlyUser)
                .Where(u => u.Artworks.Count() > 0)
                .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Select(u => new ArtistDTO
                {
                    Username = u.Username,
                    ProfilePicture = u.File.Name,
                    Location = u.UserProfile.Location,
                    Name = u.UserProfile.Name,
                    Surname = u.UserProfile.Surname,
                    Artworks = u
                        .Artworks.OrderBy(a => a.Likes.Count())
                        .Take(15)
                        .Select(a => new TinyArtworkDTO
                        {
                            Id = a.PublicId,
                            Title = a.Title,
                            PrimaryFile = new FileDTO
                            {
                                Name = a.PrimaryFile.Name,
                                Width = a.PrimaryFile.Width,
                                Height = a.PrimaryFile.Height,
                            },
                        })
                        .ToList(),
                    Tags = u.Artworks.SelectMany(a => a.Tags.Select(t => t.Title)).Take(5).ToList(),
                    FollowedByMe = !string.IsNullOrWhiteSpace(myUsername)
                        ? _context.Connections.Any(c =>
                            c.Followee.Username == u.Username && c.Follower.Username == myUsername
                        )
                        : false,
                    MonthlyArtist = u.MonthlyUser,
                })
                .ToList();

            return artists;
        }
    }
}
