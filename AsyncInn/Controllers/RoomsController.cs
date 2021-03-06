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
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return await _room.GetRooms();

        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {

            var room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize(Policy = "District Manager")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var updateRoom = await _room.Update(room);
            return Ok(updateRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Policy = "District Manager")]
        public async Task<ActionResult<Room>> PostRoom(RoomDTO room)
        {
            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        [HttpPost, Route("{roomId}/{amenitiesId}")]
        [Authorize(Policy = "District Manager")]
        //Post: api/amenitiesId/roomId
        public async Task<ActionResult<Amenity>> AddAmenityToRoom(int amenitiesId, int roomId)
        {
            await _room.AddRoomAmenity(roomId, amenitiesId);
            return Ok();
        }

        [HttpPost, Route("{roomId}/{amenitiesId}")]
        [Authorize(Policy = "District Manager")]
        public async Task<IActionResult> RemoveAmenityFromRoom(int amenitiesId, int roomId)
        {
            await _room.RemoveAmenityFromRoom(amenitiesId, roomId);
            return Ok();
        }


        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "District Manager")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            await _room.Delete(id);
            return NoContent();
        }
    }
}
