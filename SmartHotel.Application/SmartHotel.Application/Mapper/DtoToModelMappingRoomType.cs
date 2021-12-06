using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class DtoToModelMappingRoomType : Profile
    {
        public DtoToModelMappingRoomType()
        {
            RoomTypeMap();
        }

        private void RoomTypeMap()
        {
            CreateMap<RoomTypeDto, RoomType>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}