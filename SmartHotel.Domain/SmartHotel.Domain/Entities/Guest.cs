using System;
using System.Collections.Generic;

namespace SmartHotel.Domain.Entities
{
    public class Guest
    {
        public Guest()
        {
        }

        public Guest(Guid id, string name, string cpf, string email, string phoneNumber, DateTime registrationDate, Guid? pendencyId)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            Email = email;
            PhoneNumber = phoneNumber;
            RegistrationDate = registrationDate;
            PendencyId = pendencyId;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public Guid? PendencyId { get; private set; }
        public Pendency Pendency { get; private set; }
        public virtual IEnumerable<Booking> Bookings { get; private set; }

        public bool HasPending(Guest guest)
        {
            return guest.PendencyId == null;
        }
    }
}