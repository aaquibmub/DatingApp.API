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
            CreateMap<UserForRegisterDto, DbUser>();
            CreateMap<MessageForCreationDto, DbMessage>().ReverseMap();
            CreateMap<DbMessage, MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUrl, opt => opt
                    .MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(m => m.RecipientPhotoUrl, opt => opt
                    .MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
        }
    }
}