using System.Diagnostics.CodeAnalysis;
using Artportable.API.DTOs;
using Artportable.API.Entities.Models;
using AutoMapper;

namespace Artportable.API.Profiles
{
  [ExcludeFromCodeCoverage]
  public class ImageProfile : Profile
  {
    public ImageProfile()
    {
      CreateMap<UserProfile, ProfileDTO>()
        .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
        .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.User.File.Name))
        .ForMember(dest => dest.EmailDeclinedArtworkUpload, opt => opt.MapFrom(src => src.User.EmailDeclinedArtworkUpload))
        .ForMember(dest => dest.EmailInformedFollowersDate, opt => opt.MapFrom(src => src.User.EmailInformedFollowersDate))
        .ForMember(dest => dest.CoverPhoto, opt => opt.MapFrom(src => src.User.CoverPhotoFile.Name))
        .ForMember(dest => dest.Studio, opt => opt.MapFrom(src =>
          (src.StudioText != null || src.StudioLocation != null) ?
          new StudioDTO
          {
            Text = src.StudioText,
            Location = src.StudioLocation
          } : null
        ))
        .ForMember(dest => dest.SocialMedia, opt => opt.MapFrom(src =>
          (src.Website != null || src.InstagramUrl != null || src.FacebookUrl != null || src.LinkedInUrl != null || src.BehanceUrl != null || src.DribbleUrl != null) ?
          new SocialMediaDTO
          {
            Website = src.Website,
            Instagram = src.InstagramUrl,
            Facebook = src.FacebookUrl,
            LinkedIn = src.LinkedInUrl,
            Behance = src.BehanceUrl,
            Dribble = src.DribbleUrl
          } : null
        ))
        .ForMember(dest => dest.MonthlyArtist, opt => opt.MapFrom(src => src.User.MonthlyUser));

      CreateMap<Education, EducationDTO>().ReverseMap();
      CreateMap<Exhibition, ExhibitionDTO>().ReverseMap();
    }
  }
}
