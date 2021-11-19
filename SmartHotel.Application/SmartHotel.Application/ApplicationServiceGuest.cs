﻿using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;

namespace SmartHotel.Application
{
    public class ApplicationServiceGuest : IApplicationServiceGuest
    {
        private readonly IServiceGuest _serviceGuest;
        private readonly IMapper mapper;

        public ApplicationServiceGuest(IServiceGuest serviceGuest
                                      , IMapper mapper)
        {
            this._serviceGuest = serviceGuest;
            this.mapper = mapper;
        }

        public void Add(GuestDto guestDto)
        {
            var guest = mapper.Map<Guest>(guestDto);
            _serviceGuest.Add(guest);
        }

        public void Delete(GuestDto guestDto)
        {
            var guest = mapper.Map<Guest>(guestDto);
            _serviceGuest.Remove(guest);
        }

        public IEnumerable<GuestDto> ChecktHasPending()
        {
            //var guest = serviceGuest.GetGuestActive();
            //var guestDto = mapper.Map<IEnumerable<GuestDto>>(guest);

            var guest = _serviceGuest.ChecktHasPending(_serviceGuest.GetAll());
            var guestDto = mapper.Map<IEnumerable<GuestDto>>(guest);

            return guestDto;
        }

        public IEnumerable<GuestDto> GetAll()
        {
            var guest = _serviceGuest.GetAll();
            var guestDto = mapper.Map<IEnumerable<GuestDto>>(guest);

            return guestDto;
        }

        public GuestDto GetById(Guid id)
        {
            var guest = _serviceGuest.GetById(id);
            var guestDto = mapper.Map<GuestDto>(guest);

            return guestDto;
        }

        public void Update(GuestDto guestDto)
        {
            var guest = mapper.Map<Guest>(guestDto);
            _serviceGuest.Update(guest);
        }
    }
}