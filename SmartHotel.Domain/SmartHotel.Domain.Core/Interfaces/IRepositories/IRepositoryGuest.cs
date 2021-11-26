using SmartHotel.Domain.Entities;
using System;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryGuest : IRepositoryBase<Guest>
    {
        Guest GuestSearchByCpf(string cpf);

        Guest GetGuestById(Guid Id);
    }
}