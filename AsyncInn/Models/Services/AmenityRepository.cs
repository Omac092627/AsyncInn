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
    public class AmenityRepository : IAmenity
    {
        private AsyncInnDbContext _context;
        public AmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }



        public async Task<Amenity> Create(AmenityDTO amenity)
        {

            Amenity enitity = new Amenity()
            {
                Name = amenity.Name
            };
            //when I have a hotel I want to add a hotel
            _context.Entry(enitity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //the hotel gets 'saved' here, and then associated with an id.
            await _context.SaveChangesAsync();

            return enitity;
        }

        public async Task Delete(int id)
        {
            AmenityDTO amenity = await GetAmenity(id);
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            var roomAmenities = await _context.RoomAmenities.Where(x => x.AmenitiesId == id)
                                                            .Include(x => x.Room)
                                                            .ThenInclude(x => x.HotelRoom)
                                                            .ThenInclude(x => x.Hotel)
                                                            .ToListAsync();

            AmenityDTO dto = new AmenityDTO()
            {
                Id = amenity.Id,
                Name = amenity.Name,
            };


            amenity.Amenities = roomAmenities;
            return dto;
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            List<Amenity> amenities = await _context.Amenities.ToListAsync();

            List<AmenityDTO> dtos = new List<AmenityDTO>();

            foreach (var item in amenities)
            {
                dtos.Add(new AmenityDTO() { Id = item.Id, Name = item.Name });
            }

            return dtos;
        }

        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
