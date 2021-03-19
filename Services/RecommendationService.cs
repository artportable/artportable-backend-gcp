using System;
using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities;

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
      var recommendedUsers = _context.Users
        .Where(i => i.PublicId != id)
        .Take(30)
        .Join(_context.UserProfiles,
          user => user.Id,
          profile => profile.UserId,
          (user, profile) => new { User = user, Profile = profile });
      
      return recommendedUsers
        .Select(x => new RecommendationDTO() 
        {
          UserId = x.User.Id,
          Username = x.User.Username,
          Location = x.Profile.Location,
        })
        .ToList();
      
      
      // .Select(user => 
      //    new RecommendationDTO() {

      //    }
      // );
    }
  }
}
