using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Data.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
        Task<IEnumerable<Room>> GetRoomsByCategoryAsync(RoomCategory category);
        Task<bool> UpdateRoomStatusAsync(int roomId, RoomStatus status);
    }
}
