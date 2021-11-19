using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHotel.Domain.Entities
{
    public class Pendency
    {
        public Pendency(Guid id, decimal value, bool active)
        {
            Id = id;
            Value = value;
            Active = active;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public decimal Value { get; private set; }
        public bool Active { get; private set; }
    }
}