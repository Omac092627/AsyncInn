using AsyncInn.Data;
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

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        private AsyncInnDbContext _context;
        public async Task<Room> Create(Room room)
        {
            //when I have a hotel I want to add a hotel
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //the hotel gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<Room> GetRoom(int id)
        {
            //look in the db on the room table where the id is 
            //equal to the id that was brought in as an argument
            Room room = await _context.Rooms.FindAsync(id);
            var amenities = await _context.RoomAmenities.Where(x => x.RoomId == id)
                                                        .Include(x => x.Amenity)
                                                        .ToListAsync();
            room.RoomAmenities = amenities;
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.Include(x => x.RoomAmenities)
                                             .ThenInclude(x => x.Amenity)
                                             .ToListAsync();

            return rooms;
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
