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

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var room = applicationServiceRoom.GetAll();
            return Ok(room);
        }

        // GET api/
        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            return Ok(applicationServiceRoom.GetById(id));
        }

        // POST api/
        [HttpPost]
        public ActionResult Post([FromBody] RoomDto roomDTO)
        {
            try
            {
                applicationServiceRoom.Add(roomDTO);
                return Ok("Successfully Registered Room!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/
        [HttpPut]
        public ActionResult Put([FromBody] RoomDto roomDTO)
        {
            try
            {
                if (roomDTO == null) return NotFound();

                applicationServiceRoom.Update(roomDTO);
                return Ok("Room Updated Successfully!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/
        [HttpDelete()]
        public ActionResult Delete([FromBody] RoomDto roomDTO)
        {
            try
            {
                if (roomDTO == null)
                    return NotFound();

                applicationServiceRoom.Delete(roomDTO);
                return Ok("Room Successfully Removed!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}