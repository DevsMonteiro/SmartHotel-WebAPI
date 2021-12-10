using SmartHotel.Query.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Application.Interface
{
    public interface IApplicationServiceQueryGuest
    {
        IEnumerable<QueryGuestDto> GetAll();

        QueryGuestDto GetById(Guid id);
    }
}