using AutoMapper;
using SmartHotel.Query.Application.Dtos;
using SmartHotel.Query.Application.Interface;
using SmartHotel.Query.Domain.Entities;
using SmartHotel.Query.Domain.Interface.IRepositories;
using SmartHotel.Query.Domain.Interface.IServicies;
using System;
using System.Collections.Generic;

namespace SmartHotel.Query.Application
{
    public class ApplicationServiceQueryRoom : IApplicationServiceQueryRoom
    {
        private readonly IRepositoryRoom _repositoryRoom;
        private readonly IRepositoryRoomType _repositoryRoomType;
        private readonly IMapper mapper;
        private readonly IQueryServiceRoom serviceRoom;

        public ApplicationServiceQueryRoom(IMapper mapper, IRepositoryRoom repositoryRoom, IRepositoryRoomType repositoryRoomType, IQueryServiceRoom serviceRoom)
        {
            this.mapper = mapper;
            _repositoryRoom = repositoryRoom;
            _repositoryRoomType = repositoryRoomType;
            this.serviceRoom = serviceRoom;
        }

        public void Add(QueryRoomDto roomDto)
        {
            _repositoryRoom.Add(mapper.Map<Room>(roomDto));
        }

        public void Delete(QueryRoomDto roomDto)
        {
            var room = mapper.Map<Room>(roomDto);
            serviceRoom.Remove(room);
        }

        public void DeleteById(Guid id)
        {
            var guest = _repositoryRoom.GetRoomById(id);
            _repositoryRoom.Delete(guest);

        }

        public IEnumerable<QueryRoomDto> GetAll()
        {
            var roomsDomain = _repositoryRoom.GetAll();
            var room = mapper.Map<IEnumerable<QueryRoomDto>>(roomsDomain);

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

        public QueryRoomDto GetById(Guid id)
        {
            var room = _repositoryRoom.GetById(id);
            var roomDto = mapper.Map<QueryRoomDto>(room);

            return roomDto;
        }

        public IEnumerable<QueryRoomTypeDto> GetRoomType()
        {
            var roomsTypeDomain = _repositoryRoomType.GetAll();
            var roomTypeDto = mapper.Map<IEnumerable<QueryRoomTypeDto>>(roomsTypeDomain);

            return roomTypeDto;

        }

        public void Update(QueryRoomDto roomDto)
        {
            _repositoryRoom.Update(mapper.Map<Room>(roomDto));

            //var room = mapper.Map<Room>(roomDto);
            //serviceRoom.Update(room);
        }
    }
}