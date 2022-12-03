using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LMA.Data.DbProvider
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
