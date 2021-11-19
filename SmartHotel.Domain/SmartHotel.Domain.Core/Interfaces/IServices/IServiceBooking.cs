using SmartHotel.Domain.Entities;

namespace SmartHotel.Domain.Interface.IServicies
{
    public interface IServiceBooking : IServiceBase<Booking>
    {
         Booking GetGuestByCpf(string cpf);

        //IEnumerable<Booking> ChekDateRoom(IEnumerable<Booking> bookings);
    }
}