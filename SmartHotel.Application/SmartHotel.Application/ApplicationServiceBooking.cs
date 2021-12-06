using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;

namespace SmartHotel.Application
{
    public class ApplicationServiceBooking : IApplicationServiceBooking
    {
        private readonly IRepositoryBooking _repositoryBooking;
        private readonly IRepositoryRoom _repositoryRoom;
        private readonly IServiceBooking _serviceBooking;
        private readonly IServiceGuest _serviceGuest;
        private readonly IServiceRoom _serviceRoom;
        private readonly IMapper mapper;

        public ApplicationServiceBooking(IServiceBooking serviceBooking
                                        ,IRepositoryBooking repositoryBooking
                                        ,IRepositoryRoom repositoryRoom
                                        ,IServiceGuest serviceGuest
                                        ,IServiceRoom serviceRoom
                                        ,IMapper mapper)
        {
            this._serviceBooking = serviceBooking;
            this._repositoryBooking = repositoryBooking;
            this._repositoryRoom = repositoryRoom;
            this._serviceGuest = serviceGuest;
            this._serviceRoom = serviceRoom;
            this.mapper = mapper;
        }

        public void Add(BookingDto bookingDto)
        {

            var booking = mapper.Map<Booking>(bookingDto);
            _serviceBooking.Add(booking);
        }

        public void Delete(BookingDto bookingDto)
        {
            var booking = mapper.Map<Booking>(bookingDto);
            _serviceBooking.Remove(booking);
        }

        public IEnumerable<BookingDto> GetAll()
        {
            var bookingDomain = _repositoryBooking.GetAll();
            var bookingDto = mapper.Map<IEnumerable<BookingDto>>(bookingDomain);

            return bookingDto;
        }

        public BookingDto GetById(Guid id)
        {
            var booking = _serviceBooking.GetById(id);
            var bookingDto = mapper.Map<BookingDto>(booking);

            return bookingDto;
        }

        public void Update(BookingDto bookingDto)
        {
            var booking = mapper.Map<Booking>(bookingDto);
            _serviceBooking.Update(booking);
        }


        public GuestDto GuestSearchByCpf(string cpf)
        {
            var booking = _serviceGuest.GuestSearchByCpf(cpf);
            var bookingDto = mapper.Map<GuestDto>(booking);

            return bookingDto;
        }

        public IEnumerable<RoomDto> GetDdlRoom(DateTime CheckIn, DateTime CheckOut)
        {   
            var bookingRoom = _serviceRoom.GetRoomAvailable(CheckIn, CheckOut);
            var roomDto = mapper.Map<IEnumerable<RoomDto>>(bookingRoom);

            return roomDto;
        }

        public IEnumerable<BookingDto> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut)
        {
            var booking = _serviceBooking.BookingSearchByDateRange(CheckIn, CheckOut);
            var bookingDto = mapper.Map<IEnumerable<BookingDto>>(booking);

            return bookingDto;
        }

        public IEnumerable<RoomDto> RetornaQuartosDisponiveis()
        {

            //var quartosDisponiveis = _serviceRoom.QuartosDisponieveis();

            //return (IEnumerable<RoomDto>)quartosDisponiveis;
            throw new NotImplementedException();
        }

        public void DeleteById(Guid id)
        {
            var booking = _repositoryBooking.GetBookingById(id);
            _repositoryBooking.Delete(booking);
        }
    }
}