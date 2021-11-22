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

        public ServiceBooking(IRepositoryBooking _repositoryBooking)
            : base(_repositoryBooking)
        {
            this._repositoryBooking = _repositoryBooking;
        }

        public IEnumerable<Booking> ChekDateRoom(IEnumerable<Booking> bookings)
        {
            return bookings.Where(b => b.IsValid(b));
        }


        public IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut)
        {
            return _repositoryBooking.BookingSearchByDateRange(CheckIn, CheckOut);
        }

    }
}