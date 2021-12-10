using AutoMapper;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Domain.Entities;
using System;

namespace SmartHotel.Query.Application.Mapper
{
    public class DtoToModelMappingGuest : Profile
    {
        public DtoToModelMappingGuest()
        {
            GuestMap();
        }

        private void GuestMap()
        {
            CreateMap<QueryGuestDto, Guest>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x=> x.Id.HasValue? x.Id.Value: Guid.NewGuid()))
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(m => m.CPF, opt => opt.MapFrom(x => x.CPF))
                .ForMember(m => m.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(m => m.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber))
                .ForMember(m => m.RegistrationDate, opt => opt.Ignore());
        }
    }
}