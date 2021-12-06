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

        public override IEnumerable<Booking> GetAll()
        {
            return _context.Set<Booking>()
                           .Include(g => g.Guest)
                           .Include(r => r.Room)
                           .ThenInclude(rt => rt.RoomType);
        }

        public IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut)
        {
            CheckIn = CheckIn.Date;
            CheckOut = CheckOut.Date.AddDays(1).AddSeconds(-1);

            return _context.Set<Booking>()
                .Where(d => (d.CheckIn >= CheckIn && d.CheckIn <= CheckOut)   ||
                            (d.CheckOut >= CheckIn && d.CheckOut <= CheckOut) ||
                            (CheckIn >= d.CheckIn && CheckIn <= d.CheckOut)   ||
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
    }
}