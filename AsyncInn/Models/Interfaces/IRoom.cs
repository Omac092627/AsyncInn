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
        Task<Room> Create(Room room);
        //Read a Hotel
        //Get a hotel
        Task<List<Room>> GetRooms();
        //Get by Hotel id
        Task<Room> GetRoom(int id);
        //Update a Hotel
        Task<Room> Update(Room room);
        //Delete a Hotel
        Task Delete(int id);
    }
}
