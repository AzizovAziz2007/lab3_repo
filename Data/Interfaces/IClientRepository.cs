using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Data.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetByPassportAsync(string passportNumber);
        Task<Client> GetByEmailAsync(string email);
        Task<IEnumerable<Client>> GetVIPClientsAsync();
    }
}
