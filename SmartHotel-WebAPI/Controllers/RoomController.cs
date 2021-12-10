using Microsoft.AspNetCore.Mvc;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Query.Application.Interface;
using System;

namespace SmartHotel_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IApplicationServiceRoom _applicationServiceRoom;
        private readonly IApplicationServiceQueryRoom _applicationServiceQueryRoom;

        public RoomController(IApplicationServiceRoom applicationServiceRoom,
                              IApplicationServiceQueryRoom applicationServiceQueryRoom)
        {
           _applicationServiceRoom = applicationServiceRoom;
           _applicationServiceQueryRoom = applicationServiceQueryRoom;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var room = _applicationServiceQueryRoom.GetAll();
            return Ok(room);

        }

        [HttpGet("TypeRoom")]
        public IActionResult GetTypeRoom()
        {
            var roomType = _applicationServiceQueryRoom.GetRoomType();
            return Ok(roomType);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            //return Ok(applicationServiceRoom.GetById(id));
            throw new IndexOutOfRangeException();
        }

        [HttpPost]
        public ActionResult Post(RoomDto roomDTO)
        {
            try
            {
                _applicationServiceRoom.Add(roomDTO);
                return Ok(roomDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult Put(RoomDto roomDTO)
        {
            try
            {
                if (roomDTO == null) return NotFound();

                _applicationServiceRoom.Update(roomDTO);
                return Ok("Room Updated Successfully!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{Id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _applicationServiceRoom.DeleteById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}