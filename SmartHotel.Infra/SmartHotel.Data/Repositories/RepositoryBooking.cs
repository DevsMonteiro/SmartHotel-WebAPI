using Microsoft.EntityFrameworkCore;
using SmartHotel.Data.Context;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
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

        public virtual Booking GetGuestByCpf(string cpf)
        {

            return _context.Set<Booking>()
                           .Include(r => r.Guest)
                           .SingleOrDefault(x => x.Guest.CPF == cpf);
        }


    }
}