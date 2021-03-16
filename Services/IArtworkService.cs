using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IArtworkService
  {
    List<ArtworkDTO> Get();
  }
}
