using SmartHotel.Domain.Entities;
using System.Linq;

namespace SmartHotel.Domain.Interface.IRepositories
{
    public interface IRepositoryRoom : IRepositoryBase<Room>
    {
        IQueryable<Room> Query { get; }
    }
}