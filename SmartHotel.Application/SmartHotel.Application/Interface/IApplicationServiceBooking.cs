using SmartHotel.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SmartHotel.Application.Interface
{
    public interface IApplicationServiceBooking
    {
        void Add(BookingDto bookingDto);

        void Update(BookingDto bookingDto);

        void Delete(BookingDto bookingDto);

        void DeleteById(Guid id);

    }
}