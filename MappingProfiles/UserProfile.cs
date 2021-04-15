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
              .ForMember(dest => dest.CoverPhoto, opt => opt.MapFrom(src => src.User.CoverPhotoFile.Name))
              .ForMember(dest => dest.Studio, opt => opt.MapFrom(src => new StudioDTO { Text = src.StudioText, Location = src.StudioLocation }))
              .ForMember(dest => dest.SocialMedia, opt => opt.MapFrom(src => new SocialMediaDTO {
                Website = src.Website,
                Instagram = src.InstagramUrl,
                Facebook = src.FacebookUrl,
                LinkedIn = src.LinkedInUrl,
                Behance = src.BehanceUrl,
                Dribble = src.DribbleUrl
              }));

            CreateMap<Education, EducationDTO>().ReverseMap();
            CreateMap<Exhibition, ExhibitionDTO>().ReverseMap();
        }
    }
}
