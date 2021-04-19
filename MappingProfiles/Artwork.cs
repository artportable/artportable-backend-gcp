using System.Collections.Generic;
using System.Linq;
using Artportable.API.DTOs;
using Artportable.API.Entities.Models;
using AutoMapper;

namespace Artportable.API.Profiles
{
    public class ArtworkProfile : Profile
    {
        public ArtworkProfile()
        {
            CreateMap<Artwork, ArtworkDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
              .ForMember(dest => dest.Owner, opt => opt.MapFrom(src =>
                new OwnerDTO {
                  Username = src.User.Username
                }
              ))
              .ForMember(dest => dest.PrimaryFile, opt => opt.MapFrom(src => src.PrimaryFile.Name))
              .ForMember(dest => dest.SecondaryFile, opt => opt.MapFrom(src => src.SecondaryFile.Name))
              .ForMember(dest => dest.TertiaryFile, opt => opt.MapFrom(src => src.TertiaryFile.Name))
              .ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>
                src.Tags != null ?
                  src.Tags.Select(t => t.Title).ToList() :
                  new List<string>()
              ))
              .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes.Count() ));
        }
    }
}
