using SmartHotel.Domain.Entities;
using System.Collections.Generic;

namespace SmartHotel.Domain.Interface.IServicies
{
    public interface IServiceGuest : IServiceBase<Guest>
    {
        Guest GuestSearchByCpf(string cpf);
    }
}