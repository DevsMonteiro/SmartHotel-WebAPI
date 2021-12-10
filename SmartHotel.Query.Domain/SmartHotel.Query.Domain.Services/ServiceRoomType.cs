using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using SmartHotel.Query.Domain.Services;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceRoomType : ServiceBase<RoomType>, IQueryServiceRoomType
    {
        private readonly IRepositoryRoomType _repositoryRoomType;

        public ServiceRoomType(IRepositoryRoomType repositoryRoomType)
            : base(repositoryRoomType)
        {
            this._repositoryRoomType = repositoryRoomType;
        }
    }
}