﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRoom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRoom()
        {
            return await _hotelRoom.GetHotelRooms();
        }

        // GET: api/HotelRoom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomNumber);
            return hotelRoom;
        }

        // PUT: api/HotelRoom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            if (id != hotelRoom.Id)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(updateHotelRoom);

        }

        // POST: api/HotelRoom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            await _hotelRoom.Create(hotelRoom);
            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.Id }, hotelRoom);
        }

        [HttpPost]
        [Route("{hotelId}/HotelRoom/{roomNumber}")]
        //Post: api/amenitiesId/roomId
        public async Task<ActionResult<HotelRoom>> AddHotelRoom(int hotelId, int roomNumber)
        {
            await _hotelRoom.AddHotelRoom(hotelId, roomNumber);
            return Ok();
        }

        [HttpPost]
        [Route("{hotelId}/HotelRoom/{roomNumber}")]
        public async Task<IActionResult> RemoveHotelRoom(int hotelId, int roomNumber)
        {
            await _hotelRoom.RemoveHotelRoom(hotelId, roomNumber);
            return Ok();
        }



        // DELETE: api/HotelRoom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            await _hotelRoom.Delete(hotelId, roomNumber);
            return NoContent();
        }
    }
}
