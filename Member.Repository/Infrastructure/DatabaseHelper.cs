using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Member.Repository.Infrastructure
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly IConfiguration _configuration;

        public DatabaseHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnection GetConnection() => GetDbConnection("HomeDB");

        private DbConnection GetDbConnection(string database)
        {
            var connectionString = _configuration.GetConnectionString(database);
            //return new SqlConnection(connectionString);
            return new SqlConnection("Persist Security Info=False;Trusted_Connection=True; database = HomeDB; server = (local)");
        }
    }
}
