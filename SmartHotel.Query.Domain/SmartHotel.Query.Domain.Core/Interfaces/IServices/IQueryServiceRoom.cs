using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Domain.Interface.IServicies
{
    public interface IQueryServiceRoom : IQueryServiceBase<Room>
    {
        IEnumerable<Room> GetRoomAvailable(DateTime CheckIn, DateTime CheckOut, Guid id);

    }
}