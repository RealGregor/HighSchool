using Dapper;
using LMA.Data.Contracts.Writers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.MSSQL.Writers
{
    public class CartWriter : BasePersistance, IWriter<CartItemModel>
    {
        public CartWriter(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<int> Create(CartItemModel cartItem)
        {
            int result = 0;
            cartItem.Id = Guid.NewGuid();
            using (var connection = connectionFactory.Create()) {
                result = await connection.ExecuteScalarAsync<int>("INSERT INTO CartItems (id, userID, autoPartID, amount) " +
                    "VALUES(@Id, @UserID, @AutoPartID, @Amount);", cartItem);
                //await connection.ExecuteScalarAsync("INSERT INTO UserGroups (user_Id, group_Id, timeAdded) " +
                //    "VALUES(@Admin_Id, @Id, @TimeCreated);", model);
            }
            return result;
        }

        public async Task<long> Delete(Guid itemID)
        {
            long result = 0;
            using (var connection = connectionFactory.Create())
            {
                result = (await connection.ExecuteScalarAsync<long>("DELETE FROM CartItems WHERE autoPartID = '" + itemID + "';"));
                        // + (await connection.ExecuteScalarAsync<long>("DELETE FROM UserGroups WHERE group_Id = '" + id + "';"))
                        // + (await connection.ExecuteScalarAsync<long>("DELETE FROM GroupInvites WHERE group_Id = '" + id + "';"));
            }
            return result;
        }

        public async Task<long> Update(CartItemModel cartItem)
        {
            long result = 0;
            using (var connection = connectionFactory.Create())
            {
                result = await connection.ExecuteScalarAsync<long>("UPDATE CartItems SET amount = @Amount WHERE id=@Id;", cartItem);
            }
            return result;
        }
    }
}
