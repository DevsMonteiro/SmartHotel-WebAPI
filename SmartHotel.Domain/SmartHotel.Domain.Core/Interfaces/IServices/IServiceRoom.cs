using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Domain.Interface.IServicies
{
    public interface IServiceRoom : IServiceBase<Room>
    {
        IEnumerable<Room> GetRoomAvailable(DateTime CheckIn, DateTime CheckOut);

    }
}