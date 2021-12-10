using SmartHotel.Query.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Domain.Interface.IRepositories
{
    public interface IRepositoryRoom : IRepositoryBase<Room>
    {
        IQueryable<Room> Query { get; }

        Room GetRoomById(Guid id);

        IEnumerable<Room> GetRoomAvailable(DateTime CheckIn, DateTime CheckOut, Guid id);
    }
}