using System.Diagnostics.CodeAnalysis;
using Artportable.API.DTOs;
using Artportable.API.Entities.Models;
using AutoMapper;

namespace Artportable.API.Profiles
{
  [ExcludeFromCodeCoverage]
  public class StoryProfile : Profile
  {
    public StoryProfile()
    {
      CreateMap<Story, StoryDTO>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
        .ForMember(dest => dest.PrimaryFile, opt => opt.MapFrom(src => new FileDTO { Name = src.PrimaryFile.Name }))
        .ForMember(dest => dest.SecondaryFile, opt => opt.MapFrom(src => src.SecondaryFile != null ? new FileDTO { Name = src.SecondaryFile.Name } : null))
        .ForMember(dest => dest.TertiaryFile, opt => opt.MapFrom(src => src.TertiaryFile != null ? new FileDTO { Name = src.TertiaryFile.Name } : null));
    }
  }
}
