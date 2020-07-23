using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{

    public class HotelRoomRepository : IHotelRoom
    {

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        private AsyncInnDbContext _context;


        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            //when I have a hotel I want to add a hotel
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //the hotel gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoom room = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            //look in the db on the room table where the id is 
            //equal to the id that was brought in as an argument
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(hotelId);

            //include all of the amenities that the student has
            var hotelRoomNumber = await _context.HotelRoom.Where(x => x.RoomNumber == roomNumber)
                                                                .Include(x => x.HotelId)
                                                                .ToListAsync();
            hotelRoom.RoomNumber = roomNumber;
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            var room = await _context.HotelRoom.ToListAsync();
            return room;
        }


        public async Task<HotelRoom> UpdateHotelRoom(HotelRoom hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task AddHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelId = hotelId,
                RoomNumber = roomNumber,
            };
            _context.Entry(hotelRoom).State = EntityState.Added;
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
        public async Task RemoveHotelRoom(int hotelId, int roomNumber)
        {
            var result = _context.HotelRoom.FirstOrDefault(x => x.HotelId == hotelId && x.RoomNumber == roomNumber);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
