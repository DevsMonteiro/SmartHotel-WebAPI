using SmartHotel.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SmartHotel.Application.Interface
{
    public interface IApplicationServiceRoom
    {
        void Add(RoomDto roomDto);

        void Update(RoomDto roomDto);

        void Delete(RoomDto roomDto);

        IEnumerable<RoomDto> GetAll();

        RoomDto GetById(Guid id);
    }
}