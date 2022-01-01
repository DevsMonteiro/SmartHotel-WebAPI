

using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using SmartHotel.Query.Domain.Services;

namespace SmartHotel.Query.Domain.Servicies
{
    public class ServicePendency : ServiceBase<Pendency>, IQueryServicePendency
    {
        private readonly IRepositoryPendency _repositoryPendency;

        public ServicePendency(IRepositoryPendency repositoryPendency)
            : base(repositoryPendency)
        {
            _repositoryPendency = repositoryPendency;
        }
    }
}