using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {

        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        public decimal Rate { get; set; }

        public List<Room> Room { get; set; }
        public List<Hotel> Hotelroom { get; set; }

    }
}
