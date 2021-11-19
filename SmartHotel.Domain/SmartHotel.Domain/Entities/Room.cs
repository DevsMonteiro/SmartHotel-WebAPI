﻿using System;
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public string Number { get; private set; }
        public Guid RoomTypeId { get; private set; }
        public RoomType RoomType { get; private set; }
    }
}