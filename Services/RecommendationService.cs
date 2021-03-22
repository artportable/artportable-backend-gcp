using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Services
{
  public class RecommendationService : IRecommendationService
  {
     private APContext _context;

    public RecommendationService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
    }

    /// <summary>
    /// Get recommendation
    /// </summary>
    public List<RecommendationDTO> Get(Guid id) 
    {
      List<int> unRecommendableUsersId = new List<int>(); 

      var myId = _context.Users.FirstOrDefault(u => u.PublicId == id).Id;

      unRecommendableUsersId.Add(myId);
      
      var usersIFollow = _context.Connections
        .Where(c => c.FollowerId == myId)
        .Select(c => c.FolloweeId)
        .ToList();

      unRecommendableUsersId.AddRange(usersIFollow);
      
      var allUsersExceptUnRecommendable = _context.Users
        .Where(u => unRecommendableUsersId.Any(id => id != u.Id));

      var users = allUsersExceptUnRecommendable
        .Include(u => u.UserProfile)
        .Take(30)
        .Select(u => new RecommendationDTO() 
        {
          UserId = u.Id,
          Username = u.Username,
          Location = u.UserProfile.Location,
        })
        .ToList();

      return users;
    }
  }
}
