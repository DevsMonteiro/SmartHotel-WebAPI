using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartHotel.Domain.Interface.IServicies
{
    public interface IServiceBooking : IServiceBase<Booking>
    {
        IEnumerable<Booking> ChekDateRoom(IEnumerable<Booking> bookings);

        IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut);

    }
}