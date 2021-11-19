using SmartHotel.Domain.Entities;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryBooking : IRepositoryBase<Booking>
    {
        Booking GetGuestByCpf(string cpf);
    }
}