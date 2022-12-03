using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.DcProvider
{
    public interface IDcConnectionFactory
    {
        ConnectionMultiplexer Create();
    }
}
