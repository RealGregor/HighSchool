using LMA.Data.DbProvider;
using LMA.Data.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using ServiceStack;
using System.Diagnostics;
using StackExchange.Redis;

namespace LMA.HostedServices
{
    public class RedisClient : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IDistributedCache _DistributedCache;
        private const string RedisConnectionString = "localhost:6379";
        private readonly ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(RedisConnectionString);


        public RedisClient(IDistributedCache distributedCache, IDbConnectionFactory connectionFactory)
        {
            _DistributedCache = distributedCache;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(MyMethod, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private async void MyMethod(object state)
        {
            //IMPLEMENTATION
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}