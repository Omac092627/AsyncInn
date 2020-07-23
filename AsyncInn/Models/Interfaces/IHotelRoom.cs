using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom);
        //Read a Hotel
        //Get a hotel
        Task<List<HotelRoom>> GetHotelRooms();
        //Get by Hotel id
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        //Update a Hotel
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotel);
        //Delete a Hotel
        //What hotel and what room
        Task Delete(int hotelId, int roomNumber);

        Task AddHotelRoom(int hotelId, int roomNumber);
        Task RemoveHotelRoom(int hotelId, int roomNumber);



    }
}
