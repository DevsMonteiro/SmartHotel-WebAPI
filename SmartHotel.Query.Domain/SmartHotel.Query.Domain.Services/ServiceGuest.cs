 using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using SmartHotel.Query.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceGuest : ServiceBase<Guest>, IQueryServiceGuest
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