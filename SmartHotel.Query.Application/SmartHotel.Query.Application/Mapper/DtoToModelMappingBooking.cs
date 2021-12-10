using AutoMapper;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Domain.Entities;

namespace SmartHotel.Query.Application.Mapper
{
    public class DtoToModelMappingBooking : Profile
    {
        public DtoToModelMappingBooking()
        {
            BookingMap();
        }

        private void BookingMap()
        {
            CreateMap<QueryBookingDto, Booking>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.GuestId, opt => opt.MapFrom(x => x.GuestId))
                .ForMember(m => m.RoomId, opt => opt.MapFrom(x => x.RoomId))
                .ForMember(m => m.CheckIn, opt => opt.MapFrom(x => x.CheckIn))
                .ForMember(m => m.CheckOut, opt => opt.MapFrom(x => x.CheckOut))
                .ForMember(m => m.Value, opt => opt.MapFrom(x => x.Value));
        }
    }
}