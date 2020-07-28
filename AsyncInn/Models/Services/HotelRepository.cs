using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using AsyncInn.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Services
{
    public class HotelRepository : IHotel
    {
        private AsyncInnDbContext _context;
        private IHotelRoom _hotelRoom;
        public HotelRepository(AsyncInnDbContext context, IHotelRoom hotelRoom)
        {
            _context = context;
            _hotelRoom = hotelRoom;
        }


        public async Task<Hotel> Create(HotelDTO hotel)
        {

            Hotel enitity = new Hotel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,


            };
            //when I have a hotel I want to add a hotel
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //the hotel gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync();

            return enitity;
        }

        public async Task Delete(int id)
        {
            HotelDTO hotel = await GetHotel(id);
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            //look in the db on the hotel table where the id is 
            //equal to the id that was brought in as an argument
            Hotel hotel = await _context.Hotels.FindAsync(id);
            var hotelRooms = await _context.Hotels.Where(x => x.Id == id)
                                                      .Include(x => x.HotelRooms)
                                                      .ThenInclude(x => x.Room)
                                                      .ThenInclude(x => x.RoomAmenities)
                                                      .ThenInclude(x => x.Amenity)
                                                      .ToListAsync();

            List<HotelRoomDTO> hotelRoom = new List<HotelRoomDTO>();
            foreach (var item in hotelRoom)
            {
                hotelRoom.Add(new HotelRoomDTO { HotelId = item.HotelId, RoomNumber = item.RoomNumber });
            }

            HotelDTO dto = new HotelDTO()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,
                HotelRooms = hotelRoom,
            };

            return dto;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
