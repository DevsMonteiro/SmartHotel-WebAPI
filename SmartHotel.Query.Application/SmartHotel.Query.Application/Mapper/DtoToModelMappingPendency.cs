using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Query.Domain.Entities;

namespace SmartHotel.Query.Application.Mapper
{
    public class DtoToModelMappingPendency : Profile
    {
        public DtoToModelMappingPendency()
        {
            PendencyMap();
        }

        private void PendencyMap()
        {
            CreateMap<QueryPendencyDto, Pendency>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value))
                .ForMember(m => m.GuestId, opt => opt.MapFrom(x => x.GuestId));
        }
    }
}