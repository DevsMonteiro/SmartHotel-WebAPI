

using Microsoft.EntityFrameworkCore;
using SmartHotel.Query.Data.Context;
using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Data.Repositories
{
    public class RepositoryPendency : RepositoryBase<Pendency>, IRepositoryPendency
    {
        private readonly QueryDataContext _context;

        public RepositoryPendency(QueryDataContext context)
            : base(context)
        {
             _context = context;
        }

        public override IEnumerable<Pendency> GetAll()
        {
            return _context.Set<Pendency>()
                           .Include(n => n.Guest);
        }

        public Pendency CheckGuestPending(string cpf)
        {
            var checkPendency = _context.Set<Pendency>()
                         .Include(p => p.Guest)
                         .Where(g => g.Guest.CPF == cpf)
                         .FirstOrDefault();

            return checkPendency;

        }

        public IQueryable<Pendency> Query => _context.Set<Pendency>();
    }
}