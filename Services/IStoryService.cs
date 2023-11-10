using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IStoryService
  {
    List<StoryDTO> Get(string owner, string myUsername);
    StoryDTO Get(Guid id, string myUsername);
    StoryDTO Create(StoryForCreationDTO dto, Guid mySocialId);
    StoryDTO Update(StoryForUpdateDTO dto, Guid id, Guid mySocialId);
    void Delete(Guid id, string myUsername);
  }
}
