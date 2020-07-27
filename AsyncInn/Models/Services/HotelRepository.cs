﻿using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using AsyncInn.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelRepository : IHotel
    {
        private AsyncInnDbContext _context;
        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }


        public async Task<Hotel> Create(Hotel hotel)
        {
            //when I have a hotel I want to add a hotel
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //the hotel gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            //look in the db on the hotel table where the id is 
            //equal to the id that was brought in as an argument
            Hotel hotel = await _context.Hotels.FindAsync(id);
            var hotels = await _context.HotelRooms.Where(x => x.HotelId == id)
                                                    .Include(x => x.Hotel)
                                                    .ToListAsync();

            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotel = await _context.Hotels.ToListAsync();
            return hotel;
        }

        public async Task<Hotel> Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;

        }
    }
}
