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


        public Guest GuestSearchByCpf(string cpf)
        {
            return _repositoryGuest.GuestSearchByCpf(cpf);
        }
    }
}