using AutoMapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LMA.Data.UI.ViewModels.ViewModels.Order;
using LMA.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services
{
	public class OrderService : IOrderService
	{
		private readonly IWriter<OrderModel> _WriteService;
		private readonly IOrderReader<OrderModel> _ReadService;
		private readonly IMapper _mapper;
		private readonly UserService _UserService;
		private readonly IUserReader<UserModel> _UserReader;
        private readonly IAutoPartReader<AutoPartModel> _AutoPartReader;
        private readonly CartService _CartService;
        private readonly IAdminReader<AdminModel> _AdminReader;

        public OrderService(IOrderReader<OrderModel> ReadService,
                                    IWriter<OrderModel> WriteService,
                                    IMapper mapper,
                                    UserService UserService,
                                    IUserReader<UserModel> UserReader,
                                    IAutoPartReader<AutoPartModel> AutoPartReader,
                                    CartService CartService,
                                    IAdminReader<AdminModel> AdminReader
            )
		{
			_ReadService = ReadService;
			_WriteService = WriteService;
			_mapper = mapper;
			_UserService = UserService;
			_UserReader = UserReader;
            _AutoPartReader = AutoPartReader;
            _CartService = CartService;
            _AdminReader = AdminReader;
		}

		public async Task<ReturnViewModel> GetOrders(Guid userID)
		{
			ReturnViewModel result = new ReturnViewModel();

			List<OrderModel> list = await _ReadService.GetOrders(userID);
			List<OrderViewModel> res = new List<OrderViewModel>();

			foreach (OrderModel order in list)
			{
                OrderViewModel temp = _mapper.Map<OrderModel, OrderViewModel>(order);

                temp.OrderItem = new CartItemViewModel();
                AutoPartModel model = await _AutoPartReader.GetAutoPartByID(order.AutoPartID);

                temp.OrderItem.AutoPart = _mapper.Map<AutoPartModel, AutoPartViewModel>(model);
                temp.OrderItem.Amount = order.Amount;

                res.Add(temp);
            }
			result.Result.Object = res;
			result.Result.Messages.Add(new MessageViewModel(3));
			return result;

		}

        public async Task<ReturnViewModel> GetOrdersOnThisDate(Guid adminID, DateTime date) {
            ReturnViewModel result = new ReturnViewModel();

            AdminModel admin = await _AdminReader.GetAdminByID(adminID);

            if (admin == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));
                return result;
            }

            List<OrderModel> list = await _ReadService.GetOrdersOnThisDate(date.Date);

            List<OrderViewModel> res = new List<OrderViewModel>();

            foreach (OrderModel order in list) {
                OrderViewModel temp = _mapper.Map<OrderModel, OrderViewModel>(order);

                temp.OrderItem = new CartItemViewModel();

                AutoPartModel model = await _AutoPartReader.GetAutoPartByID(order.AutoPartID);
                UserModel user = await _UserReader.GetUserById(order.UserID);

                temp.OrderItem.AutoPart = _mapper.Map<AutoPartModel, AutoPartViewModel>(model);
                temp.OrderItem.User = _mapper.Map<UserModel, UserViewModel>(user);

                temp.OrderItem.Amount = order.Amount;

                res.Add(temp);
            }
            result.Result.Object = res;
            result.Result.Messages.Add(new MessageViewModel(3));
            return result;

        }

        public async Task<ReturnViewModel> AddOrder(Guid userID, AddOrderViewModel order) {
            ReturnViewModel result = new ReturnViewModel();

            UserModel user = await _UserReader.GetUserById(userID);

            int res = 0;

            if (user == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));
                return result;
            }

            if (order.Password != user.Password) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));//CHANGE
                return result;
            } else {
                Guid orderID = Guid.NewGuid();

                DateTime dateTimeNow = System.DateTime.Now;

                foreach (var v in order.CartItems) {
                    OrderModel singleItem = new OrderModel();

                    //CartItemViewModel cartItem = await _CartService.GetCartItem(userID, v.AutoPartID);

                    AutoPartModel autoPart = await _AutoPartReader.GetAutoPartByID(v.AutoPartID);

                    if (autoPart == null || v.Amount <= 0) { continue; }

                    
                    singleItem.OrderID = orderID;
                    singleItem.UserID = user.Id;
                    singleItem.AutoPartID = autoPart.Id;
                    singleItem.Date = dateTimeNow;
                    singleItem.Price = v.Amount * v.AutoPart.Price;
                    singleItem.Amount = v.Amount;

                    res = await _WriteService.Create(singleItem);
                    var cartIt = await _CartService.RemoveAllItems(v);
                }

                
            }

            result.Result.Object = res;
            result.Result.Messages.Add(new MessageViewModel(3));//TODO CHANGE 
            return result;

        }


  //      public async Task<ReturnViewModel> GetFavouriteCollaborators(Guid User_Id)
		//{
		//	ReturnViewModel result = new ReturnViewModel();

		//	List<UserModel> list = await _ReadService.GetFavouriteCollaborators(User_Id);
		//	List<UserViewModel> res = new List<UserViewModel>();
		//	foreach (UserModel user in list)
		//	{
		//		UserViewModel temp = _mapper.Map<UserModel, UserViewModel>(user);
		//		res.Add(temp);
		//	}

		//	result.Result.Object = res;
		//	result.Result.Messages.Add(new MessageViewModel(3));
		//	return result;
		//}

		//public async Task<ReturnViewModel> ChangeCollaboratorFavourite(Guid User_Id, ChangeCollaboratorFavouriteViewModel collab)
		//{
		//	ReturnViewModel result = new ReturnViewModel();

		//	CollaboratorModel temp = await _ReadService.GetCollabData(User_Id, await _UserService.GetUserId(collab.Collaborator_Email));
		//	temp.Favourite = collab.Favourite;

		//	result.Result.Object = await _WriteService.Update(new OrderModel());
		//	result.Result.Messages.Add(new MessageViewModel(3));
		//	return result;
		//}

		//public async Task<ReturnViewModel> ChangeCollaboratorNotifications(Guid User_Id, ChangeCollaboratorNotificationsViewModel collab)
		//{
		//	ReturnViewModel result = new ReturnViewModel();

		//	CollaboratorModel temp = await _ReadService.GetCollabData(User_Id, await _UserService.GetUserId(collab.Collaborator_Email));
		//	temp.Notifications = collab.Notifications;

		//	result.Result.Object = await _WriteService.Update(new OrderModel());
		//	result.Result.Messages.Add(new MessageViewModel(3));
		//	return result;
		//}
	}
}
