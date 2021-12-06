using Microsoft.AspNetCore.Mvc;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using System;

namespace SmartHotel_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IApplicationServiceRoom applicationServiceRoom;

        public RoomController(IApplicationServiceRoom applicationServiceRoom)
        {
            this.applicationServiceRoom = applicationServiceRoom;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var room = applicationServiceRoom.GetAll();
            return Ok(room);
        }

        [HttpGet("TypeRoom")]
        public IActionResult GetTypeRoom()
        {
            var roomType = applicationServiceRoom.GetRoomType();
            return Ok(roomType);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            return Ok(applicationServiceRoom.GetById(id));
        }

        [HttpPost]
        public ActionResult Post(RoomDto roomDTO)
        {
            try
            {
                applicationServiceRoom.Add(roomDTO);
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

                applicationServiceRoom.Update(roomDTO);
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
                applicationServiceRoom.DeleteById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}