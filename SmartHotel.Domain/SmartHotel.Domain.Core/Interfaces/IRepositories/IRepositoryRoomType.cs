using SmartHotel.Domain.Entities;
using System.Linq;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryRoomType : IRepositoryBase<RoomType>
    {
        IQueryable<RoomType> Query { get; }
    }
}