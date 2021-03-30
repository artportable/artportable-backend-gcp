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
    public List<RecommendationDTO> GetRecommendations(Guid id) 
    {
      List<int> unRecommendableUsersId = new List<int>(); 

      var myId = _context.Users.FirstOrDefault(u => u.PublicId == id)?.Id;

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
          UserId = u.PublicId,
          Username = u.Username,
          Location = u.UserProfile.Location,
          ProfilePicture = u.File.Name
        })
        .ToList();

      return users;
    }

    public bool Follow(Guid id, Guid userId)
    {
      var followeeId = _context.Users.FirstOrDefault(u => u.PublicId == id)?.Id;
      var myId = _context.Users.FirstOrDefault(u => u.PublicId == userId)?.Id;

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
  }
}
