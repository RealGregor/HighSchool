using LMA.Data.DcProvider;
using LMA.Services.Contracts;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace LMAServer.Hubs
{
    public class StatusSynch : Hub
    {
        private readonly IDistributedCache _DistributedCache;
        private const string RedisConnectionString = "localhost:6379";
        private readonly IUserService _UserService;


        public StatusSynch(IDistributedCache distributedCache, IDcConnectionFactory dcConnectionFactory, IUserService UserService)
        {
            _DistributedCache = distributedCache;
            _UserService = UserService;
        }
    }
}
