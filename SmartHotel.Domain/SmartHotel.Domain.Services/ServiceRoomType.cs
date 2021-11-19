using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceRoomType : ServiceBase<RoomType>, IServiceRoomType
    {
        private readonly IRepositoryRoomType _repositoryRoomType;

        public ServiceRoomType(IRepositoryRoomType _repositoryRoomType)
            : base(_repositoryRoomType)
        {
            this._repositoryRoomType = _repositoryRoomType;
        }
    }
}