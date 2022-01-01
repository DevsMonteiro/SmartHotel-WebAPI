using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHotel.Domain.Entities
{
    public class Room
    {
        public Room()
        {
        }

        public Room(Guid id, string number, Guid roomTypeId)
        {
            Id = id;
            Number = number;
            RoomTypeId = roomTypeId;
        }

        public Guid Id { get; set; }

        public string Number { get; set; }
        public Guid RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
    }
}