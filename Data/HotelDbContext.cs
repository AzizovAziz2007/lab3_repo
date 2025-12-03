using System.Data.SqlClient;

namespace HotelManagementSystem.Data
{
    /// <summary>
    /// Контекст базы данных гостиничного комплекса
    /// </summary>
    public class HotelDbContext
    {
        private readonly string _connectionString;

        public HotelDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public string ConnectionString => _connectionString;
    }
}
