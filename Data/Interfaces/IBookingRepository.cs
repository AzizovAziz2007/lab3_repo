using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Data.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByClientAsync(int clientId);
        Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime from, DateTime to);
        Task<IEnumerable<Booking>> GetActiveBookingsAsync();
    }
}
