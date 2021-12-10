using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IServicies;

namespace SmartHotel.Query.Domain.Interface.IServicies
{
    public interface IQueryServiceGuest : IQueryServiceBase<Guest>
    {
        Guest GuestSearchByCpf(string cpf);
    }
}