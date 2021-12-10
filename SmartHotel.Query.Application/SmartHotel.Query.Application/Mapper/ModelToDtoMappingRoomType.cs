using AutoMapper;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Domain.Entities;

namespace SmartHotel.Query.Application.Mapper
{
    public class ModelToDtoMappingRoomType : Profile
    {
        public ModelToDtoMappingRoomType()
        {
            RoomTypeDtoMap();
        }

        private void RoomTypeDtoMap()
        {
            CreateMap<RoomType, QueryRoomTypeDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}