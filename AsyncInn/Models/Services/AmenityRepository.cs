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
            {
                // our DB does NOT hold DTOs. It holds enitites.
                Amenity amenity = await _context.Amenities.FindAsync(id);

                AmenityDTO dto = new AmenityDTO()
                {
                    Id = amenity.Id,
                    Name = amenity.Name
                };

                return dto;
            }
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var list = await _context.Amenities.ToListAsync();

            var amenities = new List<AmenityDTO>();

            foreach (var item in list)
            {
                amenities.Add(await GetAmenity(item.Id));
            }

            return amenities;
        }

        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
