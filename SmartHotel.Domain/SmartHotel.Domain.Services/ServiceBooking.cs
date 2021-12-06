using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceBooking : ServiceBase<Booking>, IServiceBooking
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