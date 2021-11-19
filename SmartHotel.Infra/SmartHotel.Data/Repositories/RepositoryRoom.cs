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

        public IQueryable<Room> Query => _context.Set<Room>();
    }
}