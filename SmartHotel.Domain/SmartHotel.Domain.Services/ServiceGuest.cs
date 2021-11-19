using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceGuest : ServiceBase<Guest>, IServiceGuest
    {
        private readonly IRepositoryGuest _repositoryGuest;

        public ServiceGuest(IRepositoryGuest repositoryGuest)
            : base(repositoryGuest)
        {
            this._repositoryGuest = repositoryGuest;
        }

        public IEnumerable<Guest> ChecktHasPending(IEnumerable<Guest> guests)
        {
            return guests.Where(g => g.HasPending(g));
        }

        public Guest GetGuestByCpf(string cpf)
        {
            return _repositoryGuest.GetGuestByCpf(cpf);
        }
    }
}