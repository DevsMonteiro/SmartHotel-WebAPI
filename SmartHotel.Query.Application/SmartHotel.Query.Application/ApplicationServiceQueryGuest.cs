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
    public class ApplicationServiceQueryGuest : IApplicationServiceQueryGuest
    {
        private readonly IQueryServiceGuest _serviceGuest;
        private readonly IRepositoryGuest _repositoryGuest;
        private readonly IMapper _mapper;

        public ApplicationServiceQueryGuest(IQueryServiceGuest serviceGuest
                                      ,IRepositoryGuest repositoryGuest
                                      ,IMapper mapper)
        {
            _serviceGuest = serviceGuest;
            _repositoryGuest = repositoryGuest;
            _mapper = mapper;
        }


        public IEnumerable<QueryGuestDto> GetAll()
        {
            var guest = _serviceGuest.GetAll();
            var guestDto = _mapper.Map<IEnumerable<QueryGuestDto>>(guest);

            return guestDto;
        }

        public QueryGuestDto GetById(Guid id)
        {
            var guest = _serviceGuest.GetById(id);
            var guestDto = _mapper.Map<QueryGuestDto>(guest);

            return guestDto;
        }

    }
}