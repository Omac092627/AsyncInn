using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        //our composite key is both keys together

        public int AmenitiesId { get; set; }
        public int RoomId { get; set; }
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
