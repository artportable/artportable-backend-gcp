using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IFeedService
  {
    List<FeedItemDTO<ArtworkPostDTO>> Get(int page, int pageSize, Guid userId);
  }
}
