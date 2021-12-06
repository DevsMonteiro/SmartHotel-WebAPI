using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryRoom : IRepositoryBase<Room>
    {
        IQueryable<Room> Query { get; }

        IEnumerable<Room> QuartosDisponiveis();

        Room GetRoomById(Guid id);

        IEnumerable<Room> GetRoomAvailable(DateTime CheckIn, DateTime CheckOut);


    }
}