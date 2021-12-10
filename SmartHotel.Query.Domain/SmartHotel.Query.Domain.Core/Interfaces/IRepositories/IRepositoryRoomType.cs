using SmartHotel.Query.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Domain.Interface.IRepositories
{
    public interface IRepositoryRoomType : IRepositoryBase<RoomType>
    {
        IQueryable<RoomType> Query { get; }

       RoomType CalcValueRoom(DateTime CheckIn, DateTime CheckOut, Guid id);

    }
}