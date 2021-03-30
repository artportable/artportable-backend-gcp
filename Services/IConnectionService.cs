using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IConnectionService
  {
    List<RecommendationDTO> GetRecommendations(Guid id);
    bool Follow(Guid id, Guid userId);
  }
}
