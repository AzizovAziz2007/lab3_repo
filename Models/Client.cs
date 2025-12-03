using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    //Содержит личные данные клиента, статус (Regular/VIP/Blacklisted), размер скидки по программе лояльности.
    public enum ClientStatus
    {
        Regular,
        VIP,
        Blacklisted
    }

    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ClientStatus Status { get; set; }
        public decimal LoyaltyDiscount { get; set; }
        public List<Booking> BookingHistory { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Client()
        {
            BookingHistory = new List<Booking>();
        }
    }
}
