using SmartHotel.Query.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Domain.Interface.IRepositories
{
    public interface IRepositoryBooking : IRepositoryBase<Booking>
    {
        IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut);

        Booking GetBookingById(Guid id);
    }
} 