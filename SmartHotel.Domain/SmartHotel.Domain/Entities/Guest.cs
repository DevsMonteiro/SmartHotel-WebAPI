using System;
using System.Collections.Generic;

namespace SmartHotel.Domain.Entities
{
    public class Guest
    {
        public Guest()
        {
        }

        public Guest(Guid id, string name, string cpf, string email, string phoneNumber, DateTime registrationDate)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            Email = email;
            PhoneNumber = phoneNumber;
            RegistrationDate = registrationDate;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public virtual IEnumerable<Booking> Bookings { get; private set; }

    }
}