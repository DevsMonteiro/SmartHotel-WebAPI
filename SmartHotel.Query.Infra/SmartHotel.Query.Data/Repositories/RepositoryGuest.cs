using Microsoft.EntityFrameworkCore;
using SmartHotel.Query.Data.Context;
using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using System;
using System.Linq;

namespace SmartHotel.Query.Data.Repositories
{
    public class RepositoryGuest : RepositoryBase<Guest>, IRepositoryGuest
    {
        private readonly QueryDataContext _context;

        public RepositoryGuest(QueryDataContext _context)
            : base(_context)
        {
            this._context = _context;
        }

        public Guest GetGuestById(Guid Id)
        {
            IQueryable<Guest> guests = _context.Guest;

            return guests.FirstOrDefault(g => g.Id == Id);
        }

        public Guest GuestSearchByCpf(string cpf)
        {
            IQueryable<Guest> guests = _context.Guest;

            return guests.FirstOrDefault(guest => guest.CPF == cpf);
        }

        public IQueryable<Guest> Query => _context.Set<Guest>();
    }
}