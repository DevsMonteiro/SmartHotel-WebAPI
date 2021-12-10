using AutoMapper;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Domain.Entities;

namespace SmartHotel.Query.Application.Mapper
{
    public class DtoToModelMappingRoomType : Profile
    {
        public DtoToModelMappingRoomType()
        {
            RoomTypeMap();
        }

        private void RoomTypeMap()
        {
            CreateMap<QueryRoomTypeDto, RoomType>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}