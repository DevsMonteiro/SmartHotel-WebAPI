using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class DtoToModelMappingPendency : Profile
    {
        public DtoToModelMappingPendency()
        {
            PendencyMap();
        }

        private void PendencyMap()
        {
            CreateMap<PendencyDto, Pendency>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value))
                .ForMember(m => m.GuestId, opt => opt.MapFrom(x => x.GuestId));
        }
    }
}