using SmartHotel.Application.Dtos;
using SmartHotel.Query.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Application.Interface
{
    public interface IApplicationServiceQueryPendency
    {

        IEnumerable<QueryPendencyDto> GetAll();

        QueryPendencyDto GetById(Guid id);

    }
}