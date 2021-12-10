using AutoMapper;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Domain.Entities;

namespace SmartHotel.Query.Application.Mapper
{
    public class ModelToDtoMappingGuest : Profile
    {
        public ModelToDtoMappingGuest()
        {
            GuestDtoMap();
        }

        private void GuestDtoMap()
        {
            CreateMap<Guest, QueryGuestDto>()
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