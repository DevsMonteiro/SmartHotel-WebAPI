using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class ModelToDtoMappingGuest : Profile
    {
        public ModelToDtoMappingGuest()
        {
            GuestDtoMap();
        }

        private void GuestDtoMap()
        {
            CreateMap<Guest, GuestDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(m => m.CPF, opt => opt.MapFrom(x => x.CPF))
                .ForMember(m => m.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(m => m.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber))
                .ForMember(m => m.RegistrationDate, opt => opt.MapFrom(x => x.RegistrationDate))
                .ForMember(m => m.PendencyId, opt => opt.Ignore());
        }
    }
}