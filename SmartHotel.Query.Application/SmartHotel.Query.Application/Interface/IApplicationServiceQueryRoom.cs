using SmartHotel.Query.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Application.Interface
{
    public interface IApplicationServiceQueryRoom
    {
        void Add(QueryRoomDto roomDto);

        void Update(QueryRoomDto roomDto);

        void Delete(QueryRoomDto roomDto);

        IEnumerable<QueryRoomDto> GetAll();

        QueryRoomDto GetById(Guid id);

        IEnumerable<QueryRoomTypeDto> GetRoomType();

        void DeleteById(Guid id);
    }
}