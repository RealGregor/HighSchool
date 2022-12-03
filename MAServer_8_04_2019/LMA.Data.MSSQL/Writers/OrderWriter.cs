using Dapper;
using LMA.Data.Contracts.Writers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.MSSQL.Writers
{
    public class OrderWriter : BasePersistance, IWriter<OrderModel>
    {
        public OrderWriter(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<int> Create(OrderModel orderInfo)
        {
            int result = 0;
            using (var connection = connectionFactory.Create()) {
                orderInfo.ID = Guid.NewGuid();
                await connection.QueryAsync(
                 @"INSERT INTO Orders (id, orderID, userID, autoPartID, date, price, amount) " +
                 "VALUES (@ID, @OrderID, @UserID, @AutoPartID, @Date, @Price, @Amount)", orderInfo);
            }
            return result;
        }
        public async Task<long> Delete(Guid id)
        {
            long result = 0;
            using (var connection = connectionFactory.Create())
            {
                result = await connection.ExecuteScalarAsync<long>("DELETE FROM Collaborators WHERE User_Id = '" + id + "' OR Collaborator_Id ='" + id + "'; " +
                    "SELECT SCOPE_IDENTITY()");
            }
            return result;
        }

        public async Task<long> Update(OrderModel model)
        {
            long result = 0;
            using (var connection = connectionFactory.Create())
            {
                result = await connection.ExecuteScalarAsync<long>("UPDATE Collaborators SET notifications=@Notifications, favourite=@Favourite " +
                "WHERE id=@Id; SELECT SCOPE_IDENTITY()", model);
            }
            return result;
        }
    }
}
