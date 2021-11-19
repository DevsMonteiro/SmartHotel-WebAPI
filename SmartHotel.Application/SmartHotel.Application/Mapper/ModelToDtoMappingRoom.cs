using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class ModelToDtoMappingRoom : Profile
    {
        public ModelToDtoMappingRoom()
        {
            RoomDtoMap();
        }

        private void RoomDtoMap()
        {
            CreateMap<Room, RoomDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.Number, opt => opt.MapFrom(x => x.Number))
                .ForMember(m => m.RoomTypeId, opt => opt.MapFrom(x => x.RoomTypeId))
                .ForMember(m => m.RoomTypeName, opt => opt.MapFrom(x => x.RoomType.Name));
        }
    }
}