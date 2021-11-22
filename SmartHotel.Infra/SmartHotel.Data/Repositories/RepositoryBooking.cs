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
                           .ThenInclude(rt => rt.RoomType)
                           .ToList();
        }

        public IEnumerable<Booking> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut)
        {
            CheckIn = CheckIn.Date;
            CheckOut = CheckOut.Date.AddDays(1).AddSeconds(-1);

            return _context.Booking
                .Where(d => d.CheckIn >= CheckIn && d.CheckOut <= CheckOut)
                .Include(g => g.Guest)
                .Include(r => r.Room)
                .ThenInclude(rt => rt.RoomType)
                .ToList();
        }
    }
}