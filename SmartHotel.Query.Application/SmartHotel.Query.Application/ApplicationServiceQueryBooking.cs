using AutoMapper;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Application.Interface;
using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Application
{
    public class ApplicationServiceQueryBooking : IApplicationServiceQueryBooking
    {
        private readonly IRepositoryBooking _repositoryBooking;
        private readonly IRepositoryRoom _repositoryRoom;
        private readonly IRepositoryRoomType _repositoryRoomType;
        private readonly IRepositoryGuest _repositoryGuest;

        private readonly IQueryServiceBooking _serviceBooking;
        private readonly IQueryServiceGuest _serviceGuest;
        private readonly IQueryServiceRoom _serviceRoom;
        private readonly IRepositoryPendency _repositoryPendency;


        private readonly IMapper _mapper;

        public ApplicationServiceQueryBooking(IQueryServiceBooking serviceBooking
                                             ,IRepositoryBooking repositoryBooking
                                             ,IRepositoryRoom repositoryRoom
                                             ,IRepositoryRoomType repositoryRoomType
                                             ,IRepositoryGuest repositoryGuest
                                             ,IQueryServiceGuest serviceGuest
                                             ,IQueryServiceRoom serviceRoom
                                             ,IRepositoryPendency repositoryPendency
                                             ,IMapper mapper)
        {

            _repositoryBooking = repositoryBooking;
            _repositoryRoom = repositoryRoom;
            _repositoryRoomType = repositoryRoomType;
            _repositoryGuest = repositoryGuest;
            _repositoryPendency = repositoryPendency;
            _serviceBooking = serviceBooking;
            _serviceGuest = serviceGuest;
            _serviceRoom = serviceRoom;
            _mapper = mapper;
        }

        public IEnumerable<QueryBookingDto> GetAll()
        {
            var bookingDomain = _repositoryBooking.GetAll();
            var bookingDto = _mapper.Map<IEnumerable<QueryBookingDto>>(bookingDomain);

            return bookingDto;
        }

        public QueryBookingDto GetById(Guid id)
        {
            var booking = _serviceBooking.GetById(id);
            var bookingDto = _mapper.Map<QueryBookingDto>(booking);

            return bookingDto;
        }

        public QueryGuestDto GuestSearchByCpf(string cpf)
        {

            var checkPendecy = _repositoryPendency.CheckGuestPending(cpf);

            if (checkPendecy == null)
            {
                var booking = _serviceGuest.GuestSearchByCpf(cpf);
                var bookingDto = _mapper.Map<QueryGuestDto>(booking);

                return bookingDto;
            }
            else
            {
                throw new InvalidOperationException("Pendency");
            }


        }

        public IEnumerable<QueryRoomDto> GetDdlRoom(DateTime CheckIn, DateTime CheckOut, Guid id)
        {   
            var bookingRoom = _serviceRoom.GetRoomAvailable(CheckIn, CheckOut, id);
            var roomDto = _mapper.Map<IEnumerable<QueryRoomDto>>(bookingRoom);

            return roomDto;
        }

        public IEnumerable<QueryBookingDto> BookingSearchByDateRange(DateTime CheckIn, DateTime CheckOut)
        {
            var booking = _serviceBooking.BookingSearchByDateRange(CheckIn, CheckOut);
            var bookingDto = _mapper.Map<IEnumerable<QueryBookingDto>>(booking);

            return bookingDto;
        }

        public QueryRoomTypeDto GetCalcValueRoom(DateTime CheckIn, DateTime CheckOut, Guid id)
        {
            var bookingValue = _repositoryRoomType.CalcValueRoom(CheckIn, CheckOut, id);
            var roomTypeDto = _mapper.Map<QueryRoomTypeDto>(bookingValue);

            return roomTypeDto;
        }
    }
}