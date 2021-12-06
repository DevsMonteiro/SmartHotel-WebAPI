using Microsoft.EntityFrameworkCore;
using SmartHotel.Data.Context;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Data.Repositories
{
    public class RepositoryRoom : RepositoryBase<Room>, IRepositoryRoom
    {
        private readonly DataContext _context;

        public RepositoryRoom(DataContext context)
            : base(context)
        {
            this._context = context;
        }

        public virtual new void Add(Room room)
        {
            _context.Add(room);
            _context.SaveChanges();
        }

        public virtual new void Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public override IEnumerable<Room> GetAll()
        {
            return _context.Set<Room>()
                           .Include(r => r.RoomType)
                           .ToList();
        }

        public virtual new Room GetById(Guid id)
        {
            return _context.Set<Room>()
                           .Include(r => r.RoomType)
                           .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Room> QuartosDisponiveis()
        {
            return _context.Set<Room>()
                       .Include(r => r.RoomType);

            //throw new NotImplementedException();
        }

        public Room GetRoomById(Guid id)
        {
            IQueryable<Room> rooms = _context.Room;

            return rooms.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Room> GetRoomAvailable(DateTime CheckIn, DateTime CheckOut)
        {
            CheckIn = CheckIn.Date;
            CheckOut = CheckOut.Date.AddDays(1).AddSeconds(-1);

            var bookingsId = (from b in _context.Booking
                                            where (b.CheckIn >= CheckIn && b.CheckIn <= CheckOut) ||
                                                  (b.CheckOut >= CheckIn && b.CheckOut <= CheckOut) ||
                                                  (CheckIn >= b.CheckIn && CheckIn <= b.CheckOut) ||
                                                  (CheckOut >=b.CheckIn && CheckOut <= b.CheckOut)
                              select b.RoomId);
            IQueryable<Room> rooms = _context.Room
                                             .Where(b => !bookingsId.Contains(b.Id));
 

            return rooms;
    
        }

        public IQueryable<Room> Query => _context.Set<Room>();
    }
}