using SmartHotel.Data.Context;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using System.Linq;

namespace SmartHotel.Data.Repositories
{
    public class RepositoryRoomType : RepositoryBase<RoomType>, IRepositoryRoomType
    {
        private readonly DataContext _context;

        public RepositoryRoomType(DataContext _context)
            : base(_context)
        {
            this._context = _context;
        }

        public IQueryable<RoomType> Query => _context.Set<RoomType>();
    }
}