using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;

namespace SmartHotel.Domain.Servicies
{
    public class ServicePendency : ServiceBase<Pendency>, IServicePendency
    {
        private readonly IRepositoryPendency _repositoryPendency;

        public ServicePendency(IRepositoryPendency repositoryPendency)
            : base(repositoryPendency)
        {
            _repositoryPendency = repositoryPendency;
        }
    }
}