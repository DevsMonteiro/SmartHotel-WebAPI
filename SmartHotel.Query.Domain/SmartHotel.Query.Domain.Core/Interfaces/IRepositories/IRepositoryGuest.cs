using SmartHotel.Query.Domain.Entities;
using System;

namespace SmartHotel.Query.Domain.Interface.IRepositories
{
    public interface IRepositoryGuest : IRepositoryBase<Guest>
    {
        Guest GuestSearchByCpf(string cpf);

        Guest GetGuestById(Guid Id);
    }
}