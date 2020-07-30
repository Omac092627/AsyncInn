using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/Hotels")]
    [ApiController]
    [Authorize]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }


        // GET: /api/Hotels/{hotelId}/Rooms
        // Get all hotel rooms
        [HttpGet("{hotelId}/Rooms")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {

            return await _hotelRoom.GetHotelRooms(hotelId);
            
        }

        // GET: /api/Hotels/{hotelId}/Rooms/{roomNumber}
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelId, int roomNumber)
        {
            return await _hotelRoom.GetHotelRoom(hotelId, roomNumber);
        }


        // PUT: api/HotelRoom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{hotelId}/Rooms/{roomNumber}")]
        [Authorize(Policy = "District Manager")]
        [Authorize(Policy = "Property Manager")]
        [Authorize(Policy = "Agent")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelId || roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(updateHotelRoom);

        }



        //Post: api/HotelRoom/5
        [HttpPost("{hotelId}/Rooms")]
        [Authorize(Policy = "District Manager")]
        [Authorize(Policy = "Property Manager")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int hotelId, HotelRoomDTO hotelRoom)
        {
            await _hotelRoom.Create(hotelRoom, hotelId);

            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelId }, hotelRoom);
        }





        // DELETE: api/HotelRoom/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "District Manager")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            await _hotelRoom.Delete(hotelId, roomNumber);
            return NoContent();
        }





    }
}
