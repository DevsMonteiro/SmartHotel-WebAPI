using SmartHotel.Domain.Entities;
using System.Collections.Generic;

namespace SmartHotel.Domain.Interface.IServicies
{
    public interface IServiceGuest : IServiceBase<Guest>
    {
        IEnumerable<Guest> ChecktHasPending(IEnumerable<Guest> guests);

        Guest GuestSearchByCpf(string cpf);
    }
}