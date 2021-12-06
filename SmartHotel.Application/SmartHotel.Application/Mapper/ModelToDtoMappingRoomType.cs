using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class ModelToDtoMappingRoomType : Profile
    {
        public ModelToDtoMappingRoomType()
        {
            RoomTypeDtoMap();
        }

        private void RoomTypeDtoMap()
        {
            CreateMap<RoomType, RoomTypeDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}