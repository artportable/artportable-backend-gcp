using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IConnectionService
  {
    List<RecommendationDTO> GetRecommendations(string myUsername);
    bool Follow(string username, string myUsername);
    void Unfollow(string username, string myUsernamerId);
  }
}
