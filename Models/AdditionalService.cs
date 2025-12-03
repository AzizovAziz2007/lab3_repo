using System;

namespace HotelManagementSystem.Models
{
    public enum ServiceType
    {
        Restaurant,
        RoomService,
        Spa,
        Laundry,
        Transfer,
        Excursion
    }

    public class AdditionalService
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public ServiceType Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class BookingService
    {
        public int BookingServiceId { get; set; }
        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public AdditionalService Service { get; set; }
        public int Quantity { get; set; }
        public DateTime ServiceDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
