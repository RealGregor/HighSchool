using Dapper;
using LMA.Data.Contracts.Writers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.MSSQL.Writers
{
    public class AdminWriter : BasePersistance, IWriter<AdminModel>
    {
        public AdminWriter(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<int> Create(AdminModel model)
        {
            int result = 0;
            using (var connection = connectionFactory.Create())
            {
                result = await connection.ExecuteScalarAsync<int>("INSERT INTO Notifications (sender_Id, receiver_Id, timeSent, message) " +
                    "VALUES(@Sender_Id, @Receiver_Id, @TimeSent, @Message);", model);
            }
            return result;
        }

        public async Task<long> Delete(Guid id)
        {
            long result = 0;
            using (var connection = connectionFactory.Create())
            {
                result = await connection.ExecuteScalarAsync<long>("DELETE FROM Notifications WHERE id = '" + id + "';");
            }
            return result;
        }

        public Task<long> Update(AdminModel model)
        {
            throw new NotImplementedException();
        }
    }
}
