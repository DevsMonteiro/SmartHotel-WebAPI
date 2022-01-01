using SmartHotel.Query.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Domain.Interface.IRepositories
{
    public interface IRepositoryPendency : IRepositoryBase<Pendency>
    {
        IQueryable<Pendency> Query { get; }

        Pendency CheckGuestPending(string cpf);
    }
}