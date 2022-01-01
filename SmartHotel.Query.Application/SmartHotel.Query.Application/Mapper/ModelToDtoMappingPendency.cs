using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Query.Domain.Entities;

namespace SmartHotel.Query.Application.Mapper
{
    public class ModelToDtoMappingPendency : Profile
    {
        public ModelToDtoMappingPendency()
        {
            PendencyDtoMap();
        }

        private void PendencyDtoMap()
        {
            CreateMap<Pendency, QueryPendencyDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value))
                .ForMember(m => m.GuestId, opt => opt.MapFrom(x => x.GuestId));
        }
    }
}