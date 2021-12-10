using AutoMapper;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Domain.Entities;

namespace SmartHotel.Query.Application.Mapper
{
    public class DtoToModelMappingRoom : Profile
    {
        public DtoToModelMappingRoom()
        {
            RoomMap();
        }

        private void RoomMap()
        {
            CreateMap<QueryRoomDto, Room>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Number, opt => opt.MapFrom(x => x.Number))
                .ForMember(m => m.RoomTypeId, opt => opt.MapFrom(x => x.RoomTypeId))
                .ForMember(m => m.RoomType, opt => opt.Ignore());
        }
    }
}