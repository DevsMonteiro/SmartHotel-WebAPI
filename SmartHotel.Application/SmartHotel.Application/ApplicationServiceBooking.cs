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

        public void Update(BookingDto bookingDto)
        {
            var booking = mapper.Map<Booking>(bookingDto);
            _serviceBooking.Update(booking);
        }

        public void DeleteById(Guid id)
        {
            var booking = _repositoryBooking.GetBookingById(id);
            _repositoryBooking.Delete(booking);
        }
    }
}