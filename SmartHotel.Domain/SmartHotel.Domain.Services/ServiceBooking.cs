using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceBooking : ServiceBase<Booking>, IServiceBooking
    {
        private readonly IRepositoryBooking _repositoryBooking;

        public ServiceBooking(IRepositoryBooking _repositoryBooking)
            : base(_repositoryBooking)
        {
            this._repositoryBooking = _repositoryBooking;
        }

        public Booking GetGuestByCpf(string cpf)
        {
            return _repositoryBooking.GetGuestByCpf(cpf);
        }

        //public IEnumerable<Booking> ChekDateRoom(IEnumerable<Booking> bookings)
        //{
        //    return bookings.Where(b => b.IsValid(b));

        //    //throw new System.NotImplementedException();
        //}
    }
}