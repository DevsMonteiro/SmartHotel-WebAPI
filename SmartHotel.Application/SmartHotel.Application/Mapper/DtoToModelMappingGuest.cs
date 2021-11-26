using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;
using System;

namespace SmartHotel.Application.Mapper
{
    public class DtoToModelMappingGuest : Profile
    {
        public DtoToModelMappingGuest()
        {
            GuestMap();
        }

        private void GuestMap()
        {
            CreateMap<GuestDto, Guest>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x=> x.Id.HasValue? x.Id.Value: Guid.NewGuid()))
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(m => m.CPF, opt => opt.MapFrom(x => x.CPF))
                .ForMember(m => m.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(m => m.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber))
                .ForMember(m => m.RegistrationDate, opt => opt.Ignore())
                .ForMember(m => m.PendencyId, opt => opt.Ignore());
        }
    }
}