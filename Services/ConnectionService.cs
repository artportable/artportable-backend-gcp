using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Services
{
  public class ConnectionService : IConnectionService
  {
    private APContext _context;
    private readonly Random _random;

    public ConnectionService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _random = new Random();
    }

    /// <summary>
    /// Get recommendations
    /// </summary>
    public List<RecommendationDTO> GetRecommendations(string myUsername)
    {
      List<int> unRecommendableUsersId = new List<int>();

      var myId = _context.Users.FirstOrDefault(u => u.Username == myUsername)?.Id;

      if (myId == null)
      {
        return null;
      }

      unRecommendableUsersId.Add((int)myId);

      var usersIFollow = _context.Connections
        .Where(c => c.FollowerId == myId)
        .Select(c => c.FolloweeId)
        .ToList();

      unRecommendableUsersId.AddRange(usersIFollow);

      var tagsUsedByArtworksILike = _context.Likes
      .Include(l => l.User)
      .Include(l => l.Artwork)
      .ThenInclude(a => a.Tags)
      .Where(l => l.Artwork.User.Username != myUsername)
      .Where(l => l.User.Username == myUsername)
      .SelectMany(l => l.Artwork.Tags).ToList();

      var tagsUsedByArtistsIFollow = _context.Connections
      .Include(c => c.Followee)
      .ThenInclude(c => c.Artworks)
      .ThenInclude(a => a.Tags)
      .Where(c => c.FollowerId == myId)
      .SelectMany(c => c.Followee.Artworks.SelectMany(a => a.Tags))
      .ToList();

      var tagIds = tagsUsedByArtistsIFollow.Union(tagsUsedByArtworksILike)
      .GroupBy(t => t.Id)
      .Select(grp => grp.First().Id)
      .ToList();

      if (!tagIds.Any())
      {
        return _context.Users
          .FromSqlInterpolated(
            $@"SELECT *, HASHBYTES('md5',cast(id+{_random.Next()} as varchar)) AS random FROM users
            ORDER BY random OFFSET 0 ROWS")
          .Include(u => u.UserProfile)
          .Include(u => u.File)
          .Where(u => !unRecommendableUsersId.Contains(u.Id))
          .Take(30)
          .Select(u => new RecommendationDTO()
          {
            Username = u.Username,
            Location = u.UserProfile.Location,
            ProfilePicture = u.File.Name
          })
          .ToList();
      }

      var allUsersExceptUnRecommendable = _context.Users
        .Where(u => !unRecommendableUsersId.Contains(u.Id));

      var users = allUsersExceptUnRecommendable
        .Include(u => u.UserProfile)
        .Include(u => u.File)
        .Where(u => u.Artworks.Any(a => a.Tags.Any(t => tagIds.Contains(t.Id))))
        .Take(30)
        .Select(u => new RecommendationDTO()
        {
          Username = u.Username,
          Location = u.UserProfile.Location,
          ProfilePicture = u.File.Name
        })
        .ToList();

      if (users.Count() < 30)
      {
        var randomUsers = _context.Users
          .FromSqlInterpolated(
            $@"SELECT *, HASHBYTES('md5',cast(id+{_random.Next()} as varchar)) AS random FROM users
            ORDER BY random OFFSET 0 ROWS")
          .Include(u => u.UserProfile)
          .Include(u => u.File)
          .Where(u => !unRecommendableUsersId.Contains(u.Id))
          .Take(30 - users.Count())
          .Select(u => new RecommendationDTO()
          {
            Username = u.Username,
            Location = u.UserProfile.Location,
            ProfilePicture = u.File.Name
          })
          .ToList();
          users.AddRange(randomUsers);
      }

      return users;
    }

    public bool Follow(string username, string myUsername)
    {
      var followeeId = _context.Users.FirstOrDefault(u => u.Username == username)?.Id;
      var myId = _context.Users.FirstOrDefault(u => u.Username == myUsername)?.Id;

      if (myId == null || followeeId == null || myId == followeeId)
      {
        return false;
      }

      if (_context.Connections.Any(c => c.FollowerId == (int)myId && c.FolloweeId == (int)followeeId))
      {
        return true;
      }

      _context.Connections.Add(
        new Connection
        {
          FollowerId = (int)myId,
          FolloweeId = (int)followeeId
        }
      );
      _context.SaveChanges();

      return true;
    }

    public void Unfollow(string username, string myUsername)
    {
      var record = _context.Connections
        .Include(c => c.Followee)
        .Include(c => c.Follower)
        .Where(c => c.Followee.Username == username && c.Follower.Username == myUsername)
        .FirstOrDefault();

      if (record == null)
      {
        return;
      }

      _context.Connections.Remove(record);
      _context.SaveChanges();

      return;
    }
  }
}
