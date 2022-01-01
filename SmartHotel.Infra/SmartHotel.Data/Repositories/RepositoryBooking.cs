using Microsoft.EntityFrameworkCore;
using SmartHotel.Data.Context;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Data.Repositories
{
    public class RepositoryBooking : RepositoryBase<Booking>, IRepositoryBooking
    {
        private readonly DataContext _context;

        public RepositoryBooking(DataContext _context)
            : base(_context)
        {
            this._context = _context;
        }

 
        public IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut)
        {
            CheckIn = CheckIn.Date;
            CheckOut = CheckOut.Date.AddDays(1).AddSeconds(-1);

            return _context.Set<Booking>()
                .Where(d => (d.CheckIn >= CheckIn && d.CheckIn <= CheckOut) ||
                            (d.CheckOut >= CheckIn && d.CheckOut <= CheckOut) ||
                            (CheckIn >= d.CheckIn && CheckIn <= d.CheckOut) ||
                            (CheckOut >= d.CheckIn && CheckOut <= d.CheckOut))
                .Include(g => g.Guest)
                .Include(r => r.Room)
                .ThenInclude(rt => rt.RoomType);
        }

        public Booking GetBookingById(Guid id)
        {
            IQueryable<Booking> bookings = _context.Booking;

            return bookings.FirstOrDefault(g => g.Id == id);
        }


        public Booking minimum24hours(Guid id)
        {

            var minmHours = (from b in _context.Booking
                             where (b.Id == id)
                             select ((int)((b.CheckIn - DateTime.Now).TotalHours)))
                             .FirstOrDefault();

          

            if (minmHours < 24)
            {
                var bookingsValues = _context.Booking
                             .Select(v => new Booking
                             {
                                 Id = v.Id,
                                 Value = (decimal)(float)(((v.Value) * 20) / 100),
                                 CheckIn = v.CheckIn,
                                 CheckOut = v.CheckOut,
                                 RegistrationDate = v.RegistrationDate,
                                 GuestId = v.GuestId,
                                 RoomId = v.RoomId
                             })
                             .Where(b => b.Id == id)
                             .FirstOrDefault();

                return bookingsValues;
            }
            else
            {
                return null;
            }


        }

        public Booking repeatedChecks(Guid roomId, DateTime checkIn, DateTime checkOut)
        {

            var validConsut = _context.Booking
                              .Where(r => r.RoomId == roomId) 
                              .Where(i => i.CheckIn == checkIn)
                              .Where(o => o.CheckOut == checkOut)
                              .FirstOrDefault();

            return validConsut;
        }

    }                  
}