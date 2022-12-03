using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.DcProvider
{
    public class DcConnectionFactory : IDcConnectionFactory
    {
        private readonly string _ConnectionString;

        public DcConnectionFactory(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public ConnectionMultiplexer Create()
        {
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(_ConnectionString);
            return connection;
        }
    }
}
