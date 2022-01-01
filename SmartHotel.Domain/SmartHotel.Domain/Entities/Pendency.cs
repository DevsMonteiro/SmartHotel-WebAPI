using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHotel.Domain.Entities
{
    public class Pendency
    {
        public Pendency(Guid id, decimal value, Guid guestId)
        {
            Id = id;
            Value = value;
            GuestId = guestId;
        }

        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public Guid GuestId { get; set; }

    }
}