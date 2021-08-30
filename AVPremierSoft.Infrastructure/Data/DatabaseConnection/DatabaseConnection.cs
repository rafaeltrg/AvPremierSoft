using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace AVPremierSoft.Infrastructure.Data
{
    public class DatabaseConnection
    {
        private readonly IConfiguration _configuration;
        public readonly IDbConnection _db;

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
            _db = GetMySqlConnection();
        }

        private MySqlConnection GetMySqlConnection()
        {
            string cs = _configuration["ConnectionStrings:Default"];

            var csb = new MySqlConnectionStringBuilder(cs);
            var conn = new MySqlConnection(csb.ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
