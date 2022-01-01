using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class ModelToDtoMappingPendency : Profile
    {
        public ModelToDtoMappingPendency()
        {
            PendencyDtoMap();
        }

        private void PendencyDtoMap()
        {
            CreateMap<Pendency, PendencyDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value))
                .ForMember(m => m.GuestId, opt => opt.MapFrom(x => x.GuestId));
        }
    }
}