using AutoMapper;
using CafeteriaRecommendationSystem.Common.DTO.ResponseDTO;
using CafeteriaRecommendationSystem.DAL.Models;

namespace CafeteriaRecommendationSystem.DAL.Profiles
{
    public class CharacteristicProfile : Profile
    {
        public CharacteristicProfile()
        {
            CreateMap<Characteristic, ViewFoodCharacteristicsResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Characteristic, opt => opt.MapFrom(src => src.Name));
        }
    }
}
