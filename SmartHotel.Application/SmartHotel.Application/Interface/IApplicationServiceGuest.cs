using SmartHotel.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SmartHotel.Application.Interface
{
    public interface IApplicationServiceGuest
    {
        void Add(GuestDto guestDto);

        void Update(GuestDto guestDto);

        void Delete(GuestDto guestDto);

        IEnumerable<GuestDto> GetAll();

        GuestDto GetById(Guid id);

        void DeleteById(Guid id);
    }
}