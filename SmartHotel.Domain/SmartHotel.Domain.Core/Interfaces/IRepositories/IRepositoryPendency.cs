using SmartHotel.Domain.Entities;
using System;
using System.Linq;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryPendency : IRepositoryBase<Pendency>
    {

        Pendency GetPendencyById(Guid id);

    }
}