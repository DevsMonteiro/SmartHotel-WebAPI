using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using SmartHotel.Query.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Query.Domain.Servicies
{
    public class ServiceRoom : ServiceBase<Room>, IQueryServiceRoom
    {
        private readonly IRepositoryRoom _repositoryRoom;

        public ServiceRoom(IRepositoryRoom repositoryRoom)
            : base(repositoryRoom)
        {
            _repositoryRoom = repositoryRoom;
        }

        public IEnumerable<Room> GetRoomAvailable(DateTime CheckIn, DateTime CheckOut, Guid id)
        {
            var getAllRoom = _repositoryRoom.GetRoomAvailable(CheckIn, CheckOut, id);
       
            return getAllRoom;
        }
    }
}