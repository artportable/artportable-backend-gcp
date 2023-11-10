using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IStoryService
  {
    List<StoryDTO> Get(string owner, string myUsername);
    StoryDTO Get(Guid id, string myUsername);
    List<string> GetTags();
    StoryDTO Create(ArtworkForCreationDTO dto, Guid mySocialId);
    ArtworkDTO Update(ArtworkForUpdateDTO dto, Guid id, Guid mySocialId);
    void Delete(Guid id, string myUsername);
    List<TagDTO> GetTags(Guid id);
    bool Like(Guid artworkId, Guid mySocialId, out Guid owner);
    bool Unlike(Guid artworkId, Guid mySocialId, out Guid owner);
  }
}
