﻿using AsyncInn.Data;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AsyncInn.Models.Services
{
    public class RoomRepository : IRoom
    {
        private AsyncInnDbContext _context;

        private IAmenity _amenity;

        public RoomRepository(AsyncInnDbContext context, IAmenity amenity)
        {
            _context = context;
            _amenity = amenity;
        }

        public async Task<RoomDTO> Create(RoomDTO dto)
        {
            // convert a roomdto to a room entity. 

            Enum.TryParse(dto.Layout, out Layout layout);
            Room room = new Room()
            {
                Name = dto.Name,
                Layout = layout
            };

            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();

            dto.Id = room.Id;
            return dto;
        }

        public async Task Delete(int id)
        {
            RoomDTO room = await GetRoom(id);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<RoomDTO> GetRoom(int id)
        {
            //look in the db on the room table where the id is 
            //equal to the id that was brought in as an argument
            var room = await _context.Rooms.Where(x => x.Id == id)
                                                        .Include(x => x.RoomAmenities)
                                                        .FirstOrDefaultAsync();

            RoomDTO dto = new RoomDTO
            {
                Name = room.Name,
                Layout = room.Layout.ToString(),
                Id = room.Id
            };

            dto.Amenities = new List<AmenityDTO>();
            foreach (var item in room.RoomAmenities)
            {
                dto.Amenities.Add(await _amenity.GetAmenity(item.AmenitiesId));
            }

            // Convert the whole Room a RoomDTO
            // some foreach loop
            // for every amentity thats in there call
            //  _amenities.GetAmentity(id)
            // which will return you a DTO
            return dto;

        }


        public async Task<List<RoomDTO>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            List<RoomDTO> dtos = new List<RoomDTO>();

            foreach (var room in rooms)
            {
                dtos.Add(await GetRoom(room.Id));
            }

            return dtos;


        }


        public async Task<Room> Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task AddRoomAmenity(int amenitiesId, int roomId)
        {
            RoomAmenities roomAmenities = new RoomAmenities()
            {
                AmenitiesId = amenitiesId,
                RoomId = roomId,
            };
            _context.Entry(roomAmenities).State = EntityState.Added;
            await _context.SaveChangesAsync();


        }

        /// <summary>
        /// Removes a specified amenity from a specific hotel room 
        /// unqie amenityId
        /// unique roomId
        /// return saved changes
        /// </summary>
        /// <param name="amenityId"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task RemoveAmenityFromRoom(int amenityId, int roomId)
        {
            var result = _context.RoomAmenities.FirstOrDefault(x => x.AmenitiesId == amenityId && x.RoomId == roomId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
