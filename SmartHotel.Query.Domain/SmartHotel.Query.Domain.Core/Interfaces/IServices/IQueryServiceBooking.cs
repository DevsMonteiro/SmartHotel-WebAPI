using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Domain.Interface.IServicies
{
    public interface IQueryServiceBooking : IQueryServiceBase<Booking>
    {
        IEnumerable<Booking> ChekDateRoom(IEnumerable<Booking> bookings);

        IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut);

    }
}