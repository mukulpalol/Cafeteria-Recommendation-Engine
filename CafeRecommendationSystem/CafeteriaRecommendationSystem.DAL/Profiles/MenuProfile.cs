using AutoMapper;
using CafeteriaRecommendationSystem.Common;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.DAL.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuItem, MenuItemResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.GeneralSentiment, opt => opt.MapFrom(src => src.GeneralSentiment))
                .ForMember(dest => dest.SentimentScore, opt => opt.MapFrom(src => src.SentimentScore))
                .ForMember(dest => dest.Availability, opt => opt.MapFrom(src => ((AvailabilityStatusEnum)src.AvailabilityStatusId).ToString()))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => ((MenuItemTypeEnum)src.TypeId).ToString()));

            CreateMap<MenuItem, DiscardedMenuItem>()
                .ForMember(dest => dest.MenuItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MenuItem, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src=> DateTime.Today));
        }
    }
}
