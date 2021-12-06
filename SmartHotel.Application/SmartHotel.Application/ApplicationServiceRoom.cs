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

        public IEnumerable<RoomDto> GetAll()
        {
            var roomsDomain = _repositoryRoom.GetAll();
            var room = mapper.Map<IEnumerable<RoomDto>>(roomsDomain);

            #region Exemplos

            //var room = _repositoryRoom.Query
            //    .ProjectTo<RoomDto>(mapper.ConfigurationProvider)
            //    .ToList();

            //var room = _repositoryRoom.Query
            //    .Select(r => new RoomDto()
            //    {
            //        Id = r.Id,
            //        Number = r.Number,
            //        RoomTypeId = r.RoomTypeId,
            //        RoomTypeName = _repositoryRoomType.Query.FirstOrDefault(t => t.Id == r.RoomTypeId).Name
            //    });

            //var room = (from r in _repositoryRoom.Query
            //            join t in _repositoryRoomType.Query on r.RoomTypeId equals t.Id
            //            select new RoomDto()
            //            {
            //                Id = r.Id,
            //                Number = r.Number,
            //                RoomTypeId = r.RoomTypeId,
            //                RoomTypeName = t.Name
            //            }).ToList();

            #endregion Exemplos

            return room;
        }

        public RoomDto GetById(Guid id)
        {
            var room = _repositoryRoom.GetById(id);
            var roomDto = mapper.Map<RoomDto>(room);

            return roomDto;
        }

        public IEnumerable<RoomTypeDto> GetRoomType()
        {
            var roomsTypeDomain = _repositoryRoomType.GetAll();
            var roomTypeDto = mapper.Map<IEnumerable<RoomTypeDto>>(roomsTypeDomain);

            return roomTypeDto;

        }

        public void Update(RoomDto roomDto)
        {
            _repositoryRoom.Update(mapper.Map<Room>(roomDto));

            //var room = mapper.Map<Room>(roomDto);
            //serviceRoom.Update(room);
        }
    }
}