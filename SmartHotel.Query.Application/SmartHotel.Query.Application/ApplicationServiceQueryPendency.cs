using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Application.Interface;
using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Application
{
    public class ApplicationServiceQueryPendency : IApplicationServiceQueryPendency
    {

        private readonly IMapper mapper;
        private readonly IQueryServicePendency _queryServicePendency;
        private readonly IRepositoryPendency _repositoryPendency;
        private readonly IRepositoryGuest _repositoryGuest;

        public ApplicationServiceQueryPendency(IMapper mapper, IQueryServicePendency queryServicePendency, IRepositoryPendency repositoryPendency, IRepositoryGuest repositoryGuest)
        {
            this.mapper = mapper;

            _queryServicePendency = queryServicePendency;
            _repositoryPendency = repositoryPendency;
            _repositoryGuest = repositoryGuest;

        }

        public IEnumerable<QueryPendencyDto> GetAll()
        {
            var pendencyDom = _repositoryPendency.Query
                .Select(r => new QueryPendencyDto()
                {
                    Id = r.Id,
                    Value = r.Value,
                    GuestId = r.GuestId,
                    GuestName = r.Guest.Name,
                    CPF = r.Guest.CPF
                });

            //var pendencyDomain = _repositoryPendency.GetAll();
            var pendency = mapper.Map<IEnumerable<QueryPendencyDto>>(pendencyDom);

            return pendency;
        }

        QueryPendencyDto IApplicationServiceQueryPendency.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}