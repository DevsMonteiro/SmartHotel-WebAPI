using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryBooking : IRepositoryBase<Booking>
    {
        IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut);
    }
} 