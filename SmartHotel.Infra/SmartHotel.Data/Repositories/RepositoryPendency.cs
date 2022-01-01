using SmartHotel.Data.Context;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using System;
using System.Linq;

namespace SmartHotel.Data.Repositories
{
    public class RepositoryPendency : RepositoryBase<Pendency>, IRepositoryPendency
    {
        private readonly DataContext _context;

        public RepositoryPendency(DataContext context)
            : base(context)
        {
             _context = context;
        }

        Pendency IRepositoryPendency.GetPendencyById(Guid id)
        {
            var pendencys = _context.Pendency;
            return pendencys.FirstOrDefault(r => r.Id == id);
        }
    }
}