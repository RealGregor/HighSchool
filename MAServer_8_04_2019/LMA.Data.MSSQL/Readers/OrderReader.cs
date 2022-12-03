using Dapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.MSSQL.Readers
{
    public class OrderReader : BasePersistance, IOrderReader<OrderModel>
    {
        public OrderReader(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<List<OrderModel>> GetOrders(Guid userID)
        {
            List<OrderModel> result = null;
            using (var connection = connectionFactory.Create())
            {
                result = (await connection.QueryAsync<OrderModel>(
                    @"SELECT id AS Id, orderID AS OrderID, userID AS UserID, autoPartID AS AutoPartID, date AS Date, price AS Price, amount AS Amount
                    FROM Orders WHERE userID = '" + userID + "';")).ToList();
            }

            return result;
        }

        //BETWEEN '" + date.Month + "." + date.Day + "." + date.Year + " 00:00:00' AND '" + date.Month + "." + date.Day + "." + date.Year + " 23:59:59' ;")).ToList();
        public async Task<List<OrderModel>> GetOrdersOnThisDate(DateTime date) {
            List<OrderModel> result = null;
            using (var connection = connectionFactory.Create()) {
                result = (await connection.QueryAsync<OrderModel>(
                    @"SELECT id AS Id, orderID AS OrderID, userID AS UserID, autoPartID AS AutoPartID, date AS Date, price AS Price, amount AS Amount
                    FROM Orders WHERE date = '" + date.Month + "." + date.Day + "." + date.Year + "';")).ToList();
            }
            return result;
        }
    }
}
