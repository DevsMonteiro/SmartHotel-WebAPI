using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class DtoToModelMappingRoom : Profile
    {
        public DtoToModelMappingRoom()
        {
            RoomMap();
        }

        private void RoomMap()
        {
            CreateMap<RoomDto, Room>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Number, opt => opt.MapFrom(x => x.Number))
                .ForMember(m => m.RoomTypeId, opt => opt.MapFrom(x => x.RoomTypeId))
                .ForMember(m => m.RoomType, opt =>opt.Ignore());
        }
    }
}