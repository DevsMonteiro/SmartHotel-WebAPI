using SmartHotel.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SmartHotel.Application.Interface
{
    public interface IApplicationServiceBooking
    {
        void Add(BookingDto bookingDto);

        void Update(BookingDto bookingDto);

        void Delete(BookingDto bookingDto);

        IEnumerable<BookingDto> GetAll();

        BookingDto GetById(Guid id);



        GuestDto GuestSearchByCpf(string cpf);

        IEnumerable<RoomDto> GetDdlRoom(DateTime CheckIn, DateTime CheckOut);

        IEnumerable<BookingDto> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut);

        IEnumerable<RoomDto> RetornaQuartosDisponiveis();

        void DeleteById(Guid id);
    }
}