using SmartHotel.Query.Data.Context;
using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Data.Repositories
{
    public class RepositoryRoomType : RepositoryBase<RoomType>, IRepositoryRoomType
    {
        private readonly QueryDataContext _context;

        public RepositoryRoomType(QueryDataContext _context)
            : base(_context)
        {
            this._context = _context;
        }

        public IQueryable<RoomType> Query => _context.Set<RoomType>();

        public RoomType CalcValueRoom(DateTime CheckIn, DateTime CheckOut, Guid id)
        {
            CheckIn = CheckIn.Date;
            CheckOut = CheckOut.Date.AddDays(1).AddSeconds(-1);

            var days = (CheckOut - CheckIn).Days;

            var roomsType = _context.RoomType
                                              .Select(t => new RoomType {Id = t.Id
                                                                        ,Name = t.Name
                                                                        ,Value = ((decimal)(float)(t.Value * days))})
                                              .FirstOrDefault(r => r.Id == id); 

            return roomsType;
        }
    }
}