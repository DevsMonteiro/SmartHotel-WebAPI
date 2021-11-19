using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHotel.Domain.Entities
{
    public class RoomType
    {
        public RoomType()
        {
        }

        public RoomType(Guid id, string name, decimal value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public decimal Value { get; private set; }
    }
}