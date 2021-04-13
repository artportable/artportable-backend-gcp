using Artportable.API.DTOs;
using Artportable.API.Entities.Models;
using AutoMapper;

namespace Artportable.API.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<UserProfile, ProfileDTO>()
              .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
              .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.User.File.Name))
              .ForMember(dest => dest.CoverPhoto, opt => opt.MapFrom(src => src.User.CoverPhotoFile.Name));

            CreateMap<Education, EducationDTO>().ReverseMap();
            CreateMap<Exhibition, ExhibitionDTO>().ReverseMap();
        }
    }
}
