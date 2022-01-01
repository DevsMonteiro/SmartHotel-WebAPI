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
        private readonly IServicePendency _servicePendency;
        private readonly IMapper mapper;

        public ApplicationServiceBooking(IServiceBooking serviceBooking
                                        ,IRepositoryBooking repositoryBooking
                                        ,IRepositoryRoom repositoryRoom
                                        ,IServiceGuest serviceGuest
                                        ,IServiceRoom serviceRoom
                                        ,IServicePendency servicePendency
                                        ,IMapper mapper)
        {
            _serviceBooking = serviceBooking;
            _repositoryBooking = repositoryBooking;
            _repositoryRoom = repositoryRoom;
            _serviceGuest = serviceGuest;
            _serviceRoom = serviceRoom;
            _servicePendency = servicePendency;
            this.mapper = mapper;
        }

        public void Add(BookingDto bookingDto)
        {

            var valid = _repositoryBooking.repeatedChecks(bookingDto.RoomId, bookingDto.CheckIn, bookingDto.CheckOut);

            if (valid == null)
            {
                var booking = mapper.Map<Booking>(bookingDto);
                _serviceBooking.Add(booking);
            }
            else
            {
                throw new InvalidOperationException("The system does not allow duplication.");
            }
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
            var pendencyDomain = _repositoryBooking.minimum24hours(id);

            if (pendencyDomain != null)
             {
                var pendencyDto = new PendencyDto()
                {
                    Value = pendencyDomain.Value,
                    GuestId = pendencyDomain.GuestId

                };

                var pendency = mapper.Map<Pendency>(pendencyDto);
                 _servicePendency.Add(pendency);

                var booking = _repositoryBooking.GetBookingById(id);
                _repositoryBooking.Delete(booking);
            }
            else
            {
                var booking = _repositoryBooking.GetBookingById(id);
                _repositoryBooking.Delete(booking);
            }

        }

    }
}