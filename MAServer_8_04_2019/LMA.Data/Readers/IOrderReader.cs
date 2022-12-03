using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.Contracts.Readers
{
    public interface IOrderReader<IModel> where IModel : class
    {
        Task<List<OrderModel>> GetOrders(Guid userID);

        Task<List<OrderModel>> GetOrdersOnThisDate(DateTime date);
    }
}
