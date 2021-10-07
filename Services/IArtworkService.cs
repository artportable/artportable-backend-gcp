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
    ArtworkDTO Create(ArtworkForCreationDTO dto, Guid mySocialId);
    ArtworkDTO Update(ArtworkForUpdateDTO dto, Guid id, Guid mySocialId);
    void Delete(Guid id, string myUsername);
    List<TagDTO> GetTags(Guid id);
    bool Like(Guid artworkId, Guid mySocialId, out Guid owner);
    bool Unlike(Guid artworkId, Guid mySocialId, out Guid owner);
  }
}
