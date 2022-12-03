using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services.Contracts
{
    public interface IOrderService
    {
        Task<ReturnViewModel> GetOrders(Guid userID);

        Task<ReturnViewModel> GetOrdersOnThisDate(Guid adminID, DateTime date);

        Task<ReturnViewModel> AddOrder(Guid userID, AddOrderViewModel order);

        //Task<ReturnViewModel> GetFavouriteCollaborators(Guid User_Id);

        //Task<ReturnViewModel> ChangeCollaboratorFavourite(Guid User_Id, ChangeCollaboratorFavouriteViewModel collab);

        //Task<ReturnViewModel> ChangeCollaboratorNotifications(Guid User_Id, ChangeCollaboratorNotificationsViewModel collab);
    }
}
