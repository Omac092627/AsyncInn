using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
    }
}
