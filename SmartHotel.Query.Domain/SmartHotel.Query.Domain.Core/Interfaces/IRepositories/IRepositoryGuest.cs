using SmartHotel.Query.Domain.Entities;
using System;
using System.Linq;

namespace SmartHotel.Query.Domain.Interface.IRepositories
{
    public interface IRepositoryGuest : IRepositoryBase<Guest>
    {
        IQueryable<Guest> Query { get; }

        Guest GuestSearchByCpf(string cpf);

        Guest GetGuestById(Guid Id);
    }
}