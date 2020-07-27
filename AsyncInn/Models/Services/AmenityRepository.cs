using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenityRepository : IAmenity
    {
        private AsyncInnDbContext _context;
        public AmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }



        public async Task<Amenity> Create(Amenity amenity)
        {
            //when I have a hotel I want to add a hotel
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //the hotel gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            var roomAmenities = await _context.RoomAmenities.Where(x => x.AmenitiesId == id)
                                                            .Include(x => x.Room)
                                                            .ThenInclude(x => x.HotelRoom)
                                                            .ThenInclude(x => x.Hotel)
                                                            .ToListAsync();
            amenity.Amenities = roomAmenities;
            return amenity;
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenity = await _context.Amenities.ToListAsync();
            return amenity;
        }

        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
