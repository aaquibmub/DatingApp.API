using System.Linq;
using AutoMapper;
using Dtos;
using Models;

namespace Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DbUser, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src =>
                    src.Photos.FirstOrDefault(f => f.IsMain).Url))
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(
                    src => src.DateOfBirth.CalculateAge()
                ));
            CreateMap<DbUser, UserForDetailedDto>()
            .ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src =>
                    src.Photos.FirstOrDefault(f => f.IsMain).Url))
                    .ForMember(dest => dest.Age,
                opt => opt.MapFrom(
                    src => src.DateOfBirth.CalculateAge()
                ));
            CreateMap<DbPhoto, PhotoForDetailedDto>();
            CreateMap<UserForUpdateDto, DbUser>();

            CreateMap<DbPhoto, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, DbPhoto>();
        }
    }
}