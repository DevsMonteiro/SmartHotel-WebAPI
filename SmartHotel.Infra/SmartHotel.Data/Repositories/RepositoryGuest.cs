using SmartHotel.Data.Context;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using System;
using System.Linq;

namespace SmartHotel.Data.Repositories
{
    public class RepositoryGuest : RepositoryBase<Guest>, IRepositoryGuest
    {
        private readonly DataContext _context;

        public RepositoryGuest(DataContext _context)
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
    }
}