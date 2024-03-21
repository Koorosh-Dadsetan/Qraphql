using Microsoft.Data.SqlClient;
using System.Data;

namespace OneApiForAllEntity.Extensions
{
    public class DbConnectionService
    {
        private readonly string _connectionString;
        public DbConnectionService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

}
