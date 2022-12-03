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
    public class TimedHostedService : BasePersistance, IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IDistributedCache _DistributedCache;

        public TimedHostedService(IDistributedCache distributedCache, IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _DistributedCache = distributedCache;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            RedisInitialization();
            _timer = new Timer(CheckStatus, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private async void RedisInitialization()
        {
            //List<StatusModel> states = null;
            //using (var connection = connectionFactory.Create())
            //{
            //    states = (await connection.QueryAsync<StatusModel>("SELECT id AS Id, status AS Status FROM UserData")).ToList();
            //}

            //foreach (var status in states)
            //    _DistributedCache.SetString((status.Id).ToString(), (status.Status).ToString());
        }

        private async void CheckStatus(object state)
        {
            //List <StatusModel> states = null;
            //using (var connection = connectionFactory.Create())
            //{
            //    states = (await connection.QueryAsync<StatusModel>("SELECT id AS Id, status AS Status FROM UserData")).ToList();
            //}

            //foreach (var status in states) 
            //{
            //    //Check if status has been changed
            //    string status1 = await _DistributedCache.GetStringAsync((status.Id).ToString());
            //    string status2 = (status.Status).ToString();
            //    if(status1 == null)
            //    {
            //        _DistributedCache.SetString((status.Id).ToString(), (status.Status).ToString());
            //    }
            //    if ((status1 == null) || (status2 == null))
            //        continue;
            //    if (!status1.Equals(status2))
            //    {
            //        _DistributedCache.SetString((status.Id).ToString(), (status.Status).ToString());
            //    }
            //}
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