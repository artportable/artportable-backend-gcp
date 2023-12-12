using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Enums;

namespace Artportable.API.Services
{
  public interface IStoryService
  {
    List<StoryDTO> GetLatestStories(int page, int pageSize, ProductEnum minimumProduct = ProductEnum.Portfolio);
    List<StoryDTO> Get(string owner, string myUsername);
    StoryDTO Get(Guid id, string myUsername);
    public StoryDTO GetBySlug(string slug, string myUsername);
    StoryDTO Create(StoryForCreationDTO dto, Guid mySocialId);
    StoryDTO Update(StoryForUpdateDTO dto, Guid id, Guid mySocialId);
    void Delete(Guid id, string myUsername);
  }
}
