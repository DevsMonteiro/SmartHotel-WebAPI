using SmartHotel.Query.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Domain.Interface.IRepositories
{
    public interface IRepositoryBooking : IRepositoryBase<Booking>
    {
        IQueryable<Booking> Query { get; }

        IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut);

        Booking GetBookingById(Guid id);
    }
} 