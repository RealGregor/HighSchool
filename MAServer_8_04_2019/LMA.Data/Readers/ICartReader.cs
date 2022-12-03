using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.Contracts.Readers
{
    public interface ICartReader<IModel> where IModel : class
    {
        Task<CartItemModel> GetCartItem(Guid userID, Guid itemID);

        Task<List<CartItemModel>> GetCartItems(Guid userID);
    }
}
