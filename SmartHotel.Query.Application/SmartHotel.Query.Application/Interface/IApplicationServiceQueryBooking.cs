using SmartHotel.Query.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Application.Interface
{
    public interface IApplicationServiceQueryBooking
    {
        IEnumerable<QueryBookingDto> GetAll();

        QueryBookingDto GetById(Guid id);

        QueryGuestDto GuestSearchByCpf(string cpf);

        IEnumerable<QueryRoomDto> GetDdlRoom(DateTime CheckIn, DateTime CheckOut, Guid id);

        IEnumerable<QueryBookingDto> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut);

        QueryRoomTypeDto GetCalcValueRoom(DateTime CheckIn, DateTime CheckOut, Guid id);
    }
}