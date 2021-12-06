using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Domain.Servicies
{
    public class ServiceRoom : ServiceBase<Room>, IServiceRoom
    {
        private readonly IRepositoryRoom _repositoryRoom;

        public ServiceRoom(IRepositoryRoom repositoryRoom,
                           IRepositoryBooking repositoryBooking)
            : base(repositoryRoom)
        {
            this._repositoryRoom = repositoryRoom;
        }

        public IEnumerable<Room> GetRoomAvailable(DateTime CheckIn, DateTime CheckOut)
        {
            var getAllRoom = _repositoryRoom.GetRoomAvailable(CheckIn, CheckOut);
       
            return getAllRoom;
        }
    }
}