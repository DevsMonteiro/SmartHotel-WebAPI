﻿using SmartHotel.Domain.Entities;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryGuest : IRepositoryBase<Guest>
    {
        Guest GetGuestByCpf(string cpf);
    }
}