using System;
using System.Collections.Generic;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.DTOs
{
    public class BookingDTO
    {
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public List<int> ServiceIds { get; set; }

        public BookingDTO()
        {
            ServiceIds = new List<int>();
        }
    }

    public class ClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class RoomSearchDTO
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public RoomCategory? Category { get; set; }
        public int? MinCapacity { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
