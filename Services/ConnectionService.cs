using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
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
        .Include(c => c.Followee)
        .ThenInclude(c => c.Artworks)
        .ThenInclude(a => a.Tags)
        .Where(c => c.FollowerId == myId)
        .Select(c => c.Followee)
        .ToList();

      unRecommendableUsersId.AddRange(usersIFollow.Select(c => c.Id));

      var tagsUsedByArtworksILike = _context.Likes
      .Include(l => l.User)
      .Include(l => l.Artwork)
      .ThenInclude(a => a.Tags)
      .Where(l => l.Artwork.User.Username != myUsername)
      .Where(l => l.User.Username == myUsername)
      .SelectMany(l => l.Artwork.Tags).ToList();

      var tagsUsedByArtistsIFollow = usersIFollow
      .SelectMany(u => u.Artworks.SelectMany(a => a.Tags))
      .ToList();

      var tagIds = tagsUsedByArtistsIFollow.Union(tagsUsedByArtworksILike)
      .GroupBy(t => t.Id)
      .Select(grp => grp.First().Id)
      .ToList();

      if (!tagIds.Any())
      {
        return _context.Users
          .Include(u => u.UserProfile)
          .Include(u => u.File)
          .Where(u => !unRecommendableUsersId.Contains(u.Id))
          .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
          .OrderBy(u => Guid.NewGuid())
          .Take(30)
          .Select(u => new RecommendationDTO()
          {
            Username = u.Username,
            SocialId = u.SocialId,
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
        .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
        .OrderBy(u => Guid.NewGuid())
        .Take(30)
        .Select(u => new RecommendationDTO()
        {
          Username = u.Username,
          SocialId = u.SocialId,
          Location = u.UserProfile.Location,
          ProfilePicture = u.File.Name
        })
        .ToList();

      if (users.Count() < 30)
      {
        var randomUsers = _context.Users
          .Include(u => u.UserProfile)
          .Include(u => u.File)
          .Where(u => !unRecommendableUsersId.Contains(u.Id))
          .Where(u => !users.Select(u => u.Username).Contains(u.Username))
          .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
          .OrderBy(u => Guid.NewGuid())
          .Take(30 - users.Count())
          .Select(u => new RecommendationDTO()
          {
            Username = u.Username,
            SocialId = u.SocialId,
            Location = u.UserProfile.Location,
            ProfilePicture = u.File.Name
          })
          .ToList();
        users.AddRange(randomUsers);
      }

      return users;
    }

    public bool Follow(Guid socialId, Guid? mySocialId)
    {
      var followeeId = _context.Users.FirstOrDefault(u => u.SocialId == socialId)?.Id;
      var myId = _context.Users.FirstOrDefault(u => u.SocialId == mySocialId)?.Id;

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

    public void Unfollow(Guid socialId, Guid mySocialId)
    {
      var record = _context.Connections
        .Include(c => c.Followee)
        .Include(c => c.Follower)
        .Where(c => c.Followee.SocialId == socialId && c.Follower.SocialId == mySocialId)
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
