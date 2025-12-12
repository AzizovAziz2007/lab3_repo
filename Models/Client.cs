using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public enum ClientStatus
    {
        Regular,
        VIP,
        Blacklisted
    }

    // РЕФАКТОРИНГ (Подъем поля / Наследование)
    public class Client : Person
    {
        public int ClientId { get; set; }
        public string PassportNumber { get; set; }
        public ClientStatus Status { get; set; }
        public decimal LoyaltyDiscount { get; set; }
        public List<Booking> BookingHistory { get; set; }

        public Client()
        {
            BookingHistory = new List<Booking>();
        }
    }
}