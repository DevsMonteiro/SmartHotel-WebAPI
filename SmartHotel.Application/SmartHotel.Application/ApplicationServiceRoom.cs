using AutoMapper;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Interface.IRepositories;
using SmartHotel.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;

namespace SmartHotel.Application
{
    public class ApplicationServiceRoom : IApplicationServiceRoom
    {
        private readonly IRepositoryRoom _repositoryRoom;
        private readonly IRepositoryRoomType _repositoryRoomType;
        private readonly IMapper mapper;
        private readonly IServiceRoom serviceRoom;

        public ApplicationServiceRoom(IMapper mapper, IRepositoryRoom repositoryRoom, IRepositoryRoomType repositoryRoomType, IServiceRoom serviceRoom)
        {
            this.mapper = mapper;
            _repositoryRoom = repositoryRoom;
            _repositoryRoomType = repositoryRoomType;
            this.serviceRoom = serviceRoom;
        }

        public void Add(RoomDto roomDto)
        {
            _repositoryRoom.Add(mapper.Map<Room>(roomDto));
        }

        public void Delete(RoomDto roomDto)
        {
            var room = mapper.Map<Room>(roomDto);
            serviceRoom.Remove(room);
        }

        public void DeleteById(Guid id)
        {
            var guest = _repositoryRoom.GetRoomById(id);
            _repositoryRoom.Delete(guest);

        }

        public void Update(RoomDto roomDto)
        {
            _repositoryRoom.Update(mapper.Map<Room>(roomDto));

            //var room = mapper.Map<Room>(roomDto);
            //serviceRoom.Update(room);
        }
    }
}