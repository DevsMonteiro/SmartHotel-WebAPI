using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using SmartHotel.Query.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Domain.Servicies
{
    public class ServiceBooking : ServiceBase<Booking>, IQueryServiceBooking
    {
        private readonly IRepositoryBooking _repositoryBooking;

        public ServiceBooking(IRepositoryBooking repositoryBooking)
            : base(repositoryBooking)
        {
            this._repositoryBooking = repositoryBooking;
        }

        public IEnumerable<Booking> ChekDateRoom(IEnumerable<Booking> bookings)
        {
            return bookings.Where(b => b.IsValid(b));
        }

        public IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut)
        {    
          var bookingsReserved = _repositoryBooking.BookingSearchByDateRange(CheckIn, CheckOut);

          return bookingsReserved;
        }

    }
}