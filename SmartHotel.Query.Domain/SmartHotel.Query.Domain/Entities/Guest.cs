using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Domain.Entities
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

        public Guid Id { get; set; }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; }

    }
}