using System;
using System.Data;
using System.Data.SqlClient;

namespace LMA.Data.DbProvider
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _ConnectionString;

        public DbConnectionFactory(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public IDbConnection Create()
        {
            IDbConnection connection = new SqlConnection(_ConnectionString);
            connection.Open();

            return connection;
        }
    }
}
