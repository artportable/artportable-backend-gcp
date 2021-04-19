using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IArtworkService
  {
    List<ArtworkDTO> Get(string owner, string myUsername);
    ArtworkDTO Get(Guid id, string myUsername);
    List<string> GetTags();
    ArtworkDTO Create(ArtworkForCreationDTO dto, string myUsername);
    List<TagDTO> GetTags(Guid id);
    bool Like(Guid artworkId, string myUsername);
    void Unlike(Guid artworkId, string myUsername);
  }
}
