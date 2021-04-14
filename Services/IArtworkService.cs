using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IArtworkService
  {
    List<ArtworkDTO> Get(Guid? ownerId, Guid? userId);
    ArtworkDTO Get(Guid id);
    bool Like(Guid artworkId, Guid userId);
    void Unlike(Guid artworkId, Guid userId);
  }
}
