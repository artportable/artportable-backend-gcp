using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IRecommendationService
  {
    List<RecommendationDTO> Get(Guid id);
  }
}
