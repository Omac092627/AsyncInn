using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        //methods and properties that are required for the classes to implement

        //Create a Hotel
        Task<Amenity> Create(AmenityDTO amenity);
        //Read a Hotel
        //Get a hotel

        Task<List<AmenityDTO>> GetAmenities();
        //Get by Hotel id
        Task<AmenityDTO> GetAmenity(int id);
        //Update a Hotel
        Task<Amenity> Update(Amenity amenity);
        //Delete a Hotel
        Task Delete(int id);
    }
}
