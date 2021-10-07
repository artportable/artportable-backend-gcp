using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IConnectionService
  {
    List<RecommendationDTO> GetRecommendations(string myUsername);
    bool Follow(Guid username, Guid? myUsername);
    void Unfollow(Guid username, Guid myUsernamerId);
  }
}
