using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        CheckedIn,
        CheckedOut,
        Cancelled
    }

    public class Booking
    {
        public int BookingId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
        public decimal TotalCost { get; set; }
        public decimal PaidAmount { get; set; }
        public List<AdditionalService> Services { get; set; }

        public int Nights => (CheckOutDate - CheckInDate).Days;
        public decimal Balance => TotalCost - PaidAmount;

        public Booking()
        {
            Services = new List<AdditionalService>();
            BookingDate = DateTime.Now;
        }
    }
}
