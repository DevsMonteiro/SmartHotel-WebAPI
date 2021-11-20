using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class ModelToDtoMappingBooking : Profile
    {
        public ModelToDtoMappingBooking()
        {
            BookingDtoMap();
        }

        private void BookingDtoMap()
        {
            CreateMap<Booking, BookingDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(m => m.GuestId, opt =>opt.MapFrom(x => x.GuestId))
                .ForMember(m => m.NameGuest, opt => opt.MapFrom(x => x.Guest.Name))
                .ForMember(m => m.CPF, opt => opt.MapFrom(x => x.Guest.CPF))
                .ForMember(m => m.RoomId, opt => opt.MapFrom(x => x.RoomId))
                .ForMember(m => m.RoomNumber, opt => opt.MapFrom(x => x.Room.Number))
                .ForMember(m => m.RoomType, opt => opt.MapFrom(x => x.Room.RoomType.Name))
                .ForMember(m => m.CheckIn, opt => opt.MapFrom(x => x.CheckIn))
                .ForMember(m => m.CheckOut, opt => opt.MapFrom(x => x.CheckOut))
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value));
        }
    }  
}