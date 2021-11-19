﻿using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Application.Mapper
{
    public class DtoToModelMappingBooking : Profile
    {
        public DtoToModelMappingBooking()
        {
            BookingMap();
        }

        private void BookingMap()
        {
            CreateMap<BookingDto, Booking>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.GuestId, opt => opt.MapFrom(x => x.GuestId))
                .ForMember(m => m.RoomId, opt => opt.MapFrom(x => x.RoomId));
        }
    }
}