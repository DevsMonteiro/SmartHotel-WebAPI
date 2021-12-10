using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHotel.Query.Domain.Entities
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

        public Guid Id { get; private set; }

        public string Number { get; private set; }
        public Guid RoomTypeId { get; private set; }
        public RoomType RoomType { get; private set; }
    }
}