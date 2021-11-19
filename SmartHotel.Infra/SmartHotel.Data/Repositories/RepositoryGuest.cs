using SmartHotel.Data.Context;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
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

        public Guest GetGuestByCpf(string cpf)
        {
            IQueryable<Guest> guests = _context.Guest;

            guests = guests.Where(guest => guest.CPF == cpf);

            return guests.FirstOrDefault();
        }
    }
}