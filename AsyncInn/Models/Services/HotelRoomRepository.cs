using AsyncInn.Data;
using AsyncInn.Models.DTOs;
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

        private AsyncInnDbContext _context;
        private IRoom _room;
        public HotelRoomRepository(AsyncInnDbContext context, IRoom room)
        {
            _context = context;
            _room = room;
        }



        public async Task<HotelRoom> Create(HotelRoomDTO hotelRoom, int hotelId)
        {

            HotelRoom enitity = new HotelRoom()
            {
                HotelId = hotelId,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                RoomId = hotelRoom.RoomId,


            };
            //when I have a hotel I want to add a hotel
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //the hotel gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync();
            return enitity;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoomDTO room = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }





        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            List<HotelRoom> hotelRooms = await _context.HotelRooms.Where(x => x.HotelId == hotelId)
                                                                .Include(x => x.Room)
                                                                .ToListAsync();
            return hotelRooms;
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
        {
            //look in the db on the room table where the id is 
            //equal to the id that was brought in as an argument
            var hotelRoom = await _context.HotelRooms.Where(x => x.HotelId == hotelId && x.RoomNumber == roomNumber)
                                                           .Include(x => x.Hotel)
                                                           .Include(x => x.Room)
                                                           .ThenInclude(x => x.RoomAmenities)
                                                           .ThenInclude(x => x.Amenity)
                                                           .Include(x => x.Rate)
                                                           .Include(x => x.PetFriendly)
                                                           .Include(x => x.RoomId)
                                                            .FirstOrDefaultAsync();

            List<RoomDTO> list = new List<RoomDTO>();
            foreach (var item in list)
            {
                list.Add(new RoomDTO { Id = item.Id, Name = item.Name });
            }


            HotelRoomDTO dto = new HotelRoomDTO()
            {
                HotelId = hotelId,
                RoomNumber = roomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                RoomId = hotelRoom.RoomId,
            };

            return dto;
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
            var result = _context.HotelRooms.FirstOrDefault(x => x.HotelId == hotelId && x.RoomNumber == roomNumber);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
