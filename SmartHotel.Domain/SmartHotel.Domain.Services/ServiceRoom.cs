using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceRoom : ServiceBase<Room>, IServiceRoom
    {
        private readonly IRepositoryRoom _repositoryRoom;

        public ServiceRoom(IRepositoryRoom repositoryRoom)
            : base(repositoryRoom)
        {
            this._repositoryRoom = repositoryRoom;
        }
    }
}