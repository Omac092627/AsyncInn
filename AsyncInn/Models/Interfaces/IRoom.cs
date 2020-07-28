using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {

        //methods and properties that are required for the classes to implement

        //Create a Hotel
        Task<RoomDTO> Create(RoomDTO dto);
        //Read a Hotel
        //Get a hotel
        Task<List<RoomDTO>> GetRooms();
        //Get by Hotel id
        Task<RoomDTO> GetRoom(int id);
        //Update a Hotel
        Task<Room> Update(Room room);
        //Delete a Hotel
        Task Delete(int id);
        Task AddRoomAmenity(int amenitiesId, int roomId);
        Task RemoveAmenityFromRoom(int amenitiesId, int roomId);
    }
}
