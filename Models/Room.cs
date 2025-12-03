using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public enum RoomCategory
    {
        Standard,
        Comfort,
        Deluxe,
        Suite
    }

    public enum RoomStatus
    {
        Available,
        Occupied,
        Reserved,
        Maintenance
    }

    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public RoomCategory Category { get; set; }
        public RoomStatus Status { get; set; }
        public decimal BasePrice { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public List<string> Amenities { get; set; }

        public Room()
        {
            Amenities = new List<string>();
        }
    }
}
