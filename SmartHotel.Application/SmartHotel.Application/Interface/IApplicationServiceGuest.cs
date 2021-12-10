using SmartHotel.Application.Dtos;
using System;

namespace SmartHotel.Application.Interface
{
    public interface IApplicationServiceGuest
    {
        void Add(GuestDto guestDto);

        void Update(GuestDto guestDto);

        void Delete(GuestDto guestDto);

        void DeleteById(Guid id);
    }
}