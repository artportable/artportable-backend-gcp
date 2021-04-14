using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IArtworkService
  {
    List<ArtworkDTO> Get(string owner, string myUsername);
    ArtworkDTO Get(Guid id);
    List<TagDTO> GetTags(Guid id);
    bool Like(Guid artworkId, Guid userId);
    void Unlike(Guid artworkId, Guid userId);
  }
}
