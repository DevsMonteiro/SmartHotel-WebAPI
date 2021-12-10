using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;
using System;

namespace SmartHotel.Application
{
    public class ApplicationServiceGuest : IApplicationServiceGuest
    {
        private readonly IServiceGuest _serviceGuest;
        private readonly IRepositoryGuest _repositoryGuest;
        private readonly IMapper _mapper;

        public ApplicationServiceGuest(IServiceGuest serviceGuest
                                      ,IRepositoryGuest repositoryGuest
                                      ,IMapper mapper)
        {
            _serviceGuest = serviceGuest;
            _repositoryGuest = repositoryGuest;
            _mapper = mapper;
        }

        public void Add(GuestDto guestDto)
        {
            var guest = _mapper.Map<Guest>(guestDto);
            _serviceGuest.Add(guest);
        }

        public void Delete(GuestDto guestDto)
        {
            var guest = _mapper.Map<Guest>(guestDto);
            _serviceGuest.Remove(guest);
        }

        public void Update(GuestDto guestDto)
        {
            var guest = _mapper.Map<Guest>(guestDto);
            _serviceGuest.Update(guest);
        }

        public void DeleteById(Guid id)
        {
            var guest = _repositoryGuest.GetGuestById(id);
            _repositoryGuest.Delete(guest);
        }
    }
}