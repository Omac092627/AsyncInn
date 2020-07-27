using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId);
        //Read a Hotel
        //Get a hotel
        //Get by Hotel id
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);

        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        //Update a Hotel
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);
        //Delete a Hotel
        //What hotel and what room
        Task Delete(int hotelId, int roomNumber);





    }
}
