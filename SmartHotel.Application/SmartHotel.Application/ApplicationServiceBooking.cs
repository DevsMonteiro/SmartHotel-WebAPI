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
        private readonly IServiceBooking _serviceBooking;
        private readonly IServiceGuest _serviceGuest;
        private readonly IMapper mapper;

        public ApplicationServiceBooking(IServiceBooking _serviceBooking
                                        , IRepositoryBooking _repositoryBooking
                                        , IServiceGuest _serviceGuest
                                        , IMapper mapper)
        {
            this._serviceBooking = _serviceBooking;
            this._repositoryBooking = _repositoryBooking;
            this._serviceGuest = _serviceGuest;
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

        public GuestDto GetGuestByCpf(string cpf)
        {

            //return _serviceGuest.GetGuestByCpf(cpf);

            var booking = _serviceGuest.GetGuestByCpf(cpf);
            var bookingDto = mapper.Map<GuestDto>(booking);

            return bookingDto;
        }

        public void Update(BookingDto bookingDto)
        {
            var booking = mapper.Map<Booking>(bookingDto);
            _serviceBooking.Update(booking);
        }
    }
}