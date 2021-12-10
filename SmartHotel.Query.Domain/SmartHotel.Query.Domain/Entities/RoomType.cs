using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHotel.Query.Domain.Entities
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
        public Guid Id { get; set; }

        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}