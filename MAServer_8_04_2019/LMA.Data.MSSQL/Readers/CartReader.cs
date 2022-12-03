using Dapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.DbProvider;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.MSSQL.Readers
{
	public class CartReader : BasePersistance, ICartReader<CartItemModel>
	{
		public CartReader(IDbConnectionFactory connectionFactory) : base(connectionFactory)
		{
		}

		//Get all groups of user with given id
		public async Task<CartItemModel> GetCartItem(Guid userID, Guid itemID)
		{
            CartItemModel item;
			using (var connection = connectionFactory.Create())
			{
				item = await connection.QuerySingleOrDefaultAsync<CartItemModel>(
                      @"SELECT id AS Id, userID AS UserID, autoPartID AS AutoPartID, amount AS Amount FROM CartItems 
                        WHERE userID = @UserID AND autoPartID = @AutoPartID;", new {UserID = userID, AutoPartID = itemID });
			}
			return item;
		}

		//Get admins id of given group
		public async Task<List<CartItemModel>> GetCartItems(Guid userID)
		{
            List<CartItemModel> result;
            using (var connection = connectionFactory.Create())
			{
                result = (await connection.QueryAsync<CartItemModel>(
                    @"SELECT id AS Id, userID AS UserID, autoPartID AS AutoPartID, amount AS Amount FROM CartItems 
                        WHERE userID = @UserID;", new { UserID = userID})).ToList();
            }
			return result;
		}

	}
}
