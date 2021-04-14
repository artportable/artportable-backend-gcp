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

    public ConnectionService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
    }

    /// <summary>
    /// Get recommendations
    /// </summary>
    public List<RecommendationDTO> GetRecommendations(string myUsername) 
    {
      List<int> unRecommendableUsersId = new List<int>(); 

      var myId = _context.Users.FirstOrDefault(u => u.Username == myUsername)?.Id;

      if (myId == null) {
        return null;
      }

      unRecommendableUsersId.Add((int) myId);
      
      var usersIFollow = _context.Connections
        .Where(c => c.FollowerId == myId)
        .Select(c => c.FolloweeId)
        .ToList();

      unRecommendableUsersId.AddRange(usersIFollow);
      
      var allUsersExceptUnRecommendable = _context.Users
        .Where(u => !unRecommendableUsersId.Contains(u.Id));

      var users = allUsersExceptUnRecommendable
        .Include(u => u.UserProfile)
        .Include(u => u.File)
        .Take(30)
        .Select(u => new RecommendationDTO() 
        {
          Username = u.Username,
          Location = u.UserProfile.Location,
          ProfilePicture = u.File.Name
        })
        .ToList();

      return users;
    }

    public bool Follow(string username, string myUsername)
    {
      var followeeId = _context.Users.FirstOrDefault(u => u.Username == username)?.Id;
      var myId = _context.Users.FirstOrDefault(u => u.Username == myUsername)?.Id;

      if (myId == null || followeeId == null || myId == followeeId) {
        return false;
      }

      if (_context.Connections.Any(c => c.FollowerId == (int) myId && c.FolloweeId == (int) followeeId))
      {
        return true;
      }

      _context.Connections.Add(
        new Connection
        {
          FollowerId = (int) myId,
          FolloweeId = (int) followeeId
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

      if (record == null) {
        return;
      }

      _context.Connections.Remove(record);
      _context.SaveChanges();

      return;
    }
  }
}
