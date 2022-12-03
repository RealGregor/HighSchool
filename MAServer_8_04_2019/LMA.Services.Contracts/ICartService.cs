using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services.Contracts
{
    public interface ICartService
    {
        Task<CartItemViewModel> GetCartItem(Guid userID, Guid autoPartID);

        Task<ReturnViewModel> GetCartItems(Guid userID);
        
        Task<ReturnViewModel> AddItem(CartItemViewModel item);

        Task<ReturnViewModel> RemoveSomeItems(CartItemViewModel item);

        Task<ReturnViewModel> RemoveAllItems(CartItemViewModel item);
    }
}
