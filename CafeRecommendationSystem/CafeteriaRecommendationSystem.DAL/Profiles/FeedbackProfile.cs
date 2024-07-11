using AutoMapper;
using CafeteriaRecommendationSystem.Common.DTO.RequestDTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.DAL.Profiles
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<FeedbackRequestDTO, Feedback>()
                .ForMember(dest => dest.MenuItemId, opt => opt.MapFrom(src => src.MenuItemId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));

            CreateMap<DiscardedMenuItemFeedbackRequestDTO, DiscardedMenuItemFeedback>()
                .ForMember(dest => dest.DiscardedMenuItemId, opt => opt.MapFrom(src => src.MenuItemId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Feedback, opt => opt.MapFrom(src => src.Feedback));
        }
    }
}
