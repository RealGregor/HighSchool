using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.DbProvider
{
    public class BasePersistance
    {
        protected readonly IDbConnectionFactory connectionFactory;

        public BasePersistance(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
    }
}
