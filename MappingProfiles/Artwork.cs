using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities.Models;
using AutoMapper;

namespace Artportable.API.Profiles
{
  [ExcludeFromCodeCoverage]
  public class ArtworkProfile : Profile
  {
    public ArtworkProfile()
    {
      CreateMap<Artwork, ArtworkDTO>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
        .ForMember(dest => dest.Owner, opt => opt.MapFrom(src =>
          new OwnerDTO
          {
            Username = src.User.Username
          }
        ))
        .ForMember(dest => dest.PrimaryFile, opt => opt.MapFrom(src => new FileDTO { Name = src.PrimaryFile.Name }))
        .ForMember(dest => dest.SecondaryFile, opt => opt.MapFrom(src => src.SecondaryFile != null ? new FileDTO { Name = src.SecondaryFile.Name } : null))
        .ForMember(dest => dest.TertiaryFile, opt => opt.MapFrom(src => src.TertiaryFile != null ? new FileDTO { Name = src.TertiaryFile.Name } : null))
        .ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>
          src.Tags != null ?
            src.Tags.Select(t => t.Title).ToList() :
            new List<string>()
        ))
        .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes.Count()));
    }
  }
}
