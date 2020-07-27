using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        //methods and properties that are required for the classes to implement

        //Create a Hotel
        Task<Hotel> Create(Hotel hotel);
        //Read a Hotel
        //Get a hotel
        Task<List<Hotel>> GetHotels();
        //Get by Hotel id
        Task<Hotel> GetHotel(int id);
        //Update a Hotel
        Task Update(Hotel hotel);
        //Delete a Hotel
        Task Delete(int id);


    }
}
