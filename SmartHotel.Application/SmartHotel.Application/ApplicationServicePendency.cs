using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Domain.Interface.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Application
{
    public class ApplicationServicePendency : IApplicationServicePendency
    {

        private readonly IMapper mapper;
        private readonly IRepositoryPendency _repositoryPendency;


        public ApplicationServicePendency(IMapper mapper, IRepositoryPendency repositoryPendency)
        {
            this.mapper = mapper;
             _repositoryPendency = repositoryPendency;


        }

        public void DeleteById(Guid id)
        {
            var pendencydomain = _repositoryPendency.GetPendencyById(id);
            _repositoryPendency.Delete(pendencydomain);
        }
    }
}