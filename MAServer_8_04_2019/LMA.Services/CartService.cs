using AutoMapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LMA.Services.Contracts;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services
{
	public class CartService : ICartService
	{
		private readonly ICartReader<CartItemModel> _ReadService;
		private readonly IWriter<CartItemModel> _WriteService;
		private readonly IMapper _mapper;
		private readonly UserService _UserService;
		private readonly IAutoPartReader<AutoPartModel> _autoPartReader;

        public CartService(ICartReader<CartItemModel> ReadService,
							IWriter<CartItemModel> WriteService,
							IMapper mapper,
							UserService userService,
							IAutoPartReader<AutoPartModel> autoPartReader)
		{
			_ReadService = ReadService;
			_WriteService = WriteService;
			_mapper = mapper;
			_UserService = userService;
            _autoPartReader = autoPartReader;
		}
        
		//Add new cartItem / change the amount of it
		public async Task<ReturnViewModel> AddItem(CartItemViewModel item)
		{
			ReturnViewModel result = new ReturnViewModel();
            
            CartItemModel itemExists = await _ReadService.GetCartItem(item.UserID, item.AutoPartID);

            //RATHER DO IT FROM SERVICE? -> NO BULLSHIT IN GUID
            AutoPartModel autoPart = await _autoPartReader.GetAutoPartByID(item.AutoPartID);

            if (autoPart == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));
                return result;
            }

            if (itemExists == null) {
                CartItemModel newItem = _mapper.Map<CartItemViewModel, CartItemModel>(item);

                if (item.Amount > 0) {

                    int res = await _WriteService.Create(newItem);
                    
                    item.AutoPart = _mapper.Map<AutoPartModel, AutoPartViewModel>(autoPart);

                    result.Result.Object = item;
                    result.Result.Messages.Add(new MessageViewModel(3));

                } else {
                    result.Ok = false;
                    result.Result.Messages.Add(new MessageViewModel(14));
                    return result;
                }
                
            } else {
                if (item.Amount > 0) {

                    itemExists.Amount += item.Amount;

                    long res = await _WriteService.Update(itemExists);

                    CartItemViewModel createdItem = _mapper.Map<CartItemModel, CartItemViewModel>(itemExists);

                    createdItem.AutoPart = _mapper.Map<AutoPartModel, AutoPartViewModel>(autoPart);

                    result.Result.Object = createdItem;
                    result.Result.Messages.Add(new MessageViewModel(3));

                } else {
                    result.Ok = false;
                    result.Result.Messages.Add(new MessageViewModel(14));
                    return result;
                }
            }


			//Convert GroupViewModel -> GroupModel
			
			//Set current time
			
            //Add new group to database
            
			return result;
		}

        //Add new cartItem / change the amount of it
        public async Task<ReturnViewModel> RemoveSomeItems(CartItemViewModel item) {
            ReturnViewModel result = new ReturnViewModel();

            CartItemModel itemExists = await _ReadService.GetCartItem(item.UserID, item.AutoPartID);

            //RATHER DO IT FROM SERVICE? -> NO BULLSHIT IN GUID
            AutoPartModel autoPart = await _autoPartReader.GetAutoPartByID(item.AutoPartID);

            if (autoPart == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));
                return result;
            }

            if (itemExists == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));
                return result;
            } else {
                if (item.Amount > 0) {

                    itemExists.Amount -= item.Amount;

                    long res = await _WriteService.Update(itemExists);

                    CartItemViewModel createdItem = _mapper.Map<CartItemModel, CartItemViewModel>(itemExists);

                    createdItem.AutoPart = _mapper.Map<AutoPartModel, AutoPartViewModel>(autoPart);

                    result.Result.Object = createdItem;
                    result.Result.Messages.Add(new MessageViewModel(3));

                } else {
                    return await this.RemoveAllItems(item);
                }
            }
            return result;
        }

        //Add new cartItem / change the amount of it
        public async Task<ReturnViewModel> RemoveAllItems(CartItemViewModel item) {
            ReturnViewModel result = new ReturnViewModel();

            CartItemModel itemExists = await _ReadService.GetCartItem(item.UserID, item.AutoPartID);

            //RATHER DO IT FROM SERVICE? -> NO BULLSHIT IN GUID
            AutoPartModel autoPart = await _autoPartReader.GetAutoPartByID(item.AutoPartID);

            if (autoPart == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));
                return result;
            }

            if (itemExists == null) {
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(14));
                return result;
            } else {
                long res = await _WriteService.Delete(itemExists.AutoPartID);

                CartItemViewModel createdItem = _mapper.Map<CartItemModel, CartItemViewModel>(itemExists);

                createdItem.AutoPart = _mapper.Map<AutoPartModel, AutoPartViewModel>(autoPart);

                result.Result.Object = createdItem;
                result.Result.Messages.Add(new MessageViewModel(3));
            }
            return result;
        }

        //GET ALL THE CART ITEMS FOR THE GIVEN GUID - USER
        public async Task<ReturnViewModel> GetCartItems(Guid userID) {
            ReturnViewModel result = new ReturnViewModel();
            //Get all invites of user
            List<CartItemModel> list = await _ReadService.GetCartItems(userID); //false == requests
            List<CartItemViewModel> res = new List<CartItemViewModel>();
            //Check if there is at least one invite
            if (list == null) {
                result.Result.Object = res;
                result.Result.Messages.Add(new MessageViewModel(3));
                return result;
            }

            //For each invite create GroupInviteViewModel and add it to the list
            foreach (CartItemModel cartItem in list) {
                CartItemViewModel model = _mapper.Map<CartItemModel, CartItemViewModel>(cartItem);
                /*
                IS THIS A GOOD IDEA --> 10^6 REQUEST * 10^6 PEOPLE DOING IT IS IT GONNA MANAGE?
                */
                AutoPartModel autoPart = await _autoPartReader.GetAutoPartByID(model.AutoPartID);

                model.AutoPart = _mapper.Map<AutoPartModel, AutoPartViewModel>(autoPart);

                res.Add(model);
            }
            result.Result.Object = res;
            result.Result.Messages.Add(new MessageViewModel(3)); //CHANGE MESSAGE
            return result;
        }

        //GET THE CART ITEM -- NOT SMART TO DO IT LIKE DIS BUT FUK IT
        public async Task<CartItemViewModel> GetCartItem(Guid userID, Guid autoPartID) {
            CartItemModel cartItem = await _ReadService.GetCartItem(userID, autoPartID); //false == requests
            if (cartItem == null) {
                return null;
            }

            CartItemViewModel model = _mapper.Map<CartItemModel, CartItemViewModel>(cartItem);
            /*
             IS THIS A GOOD IDEA --> 10^6 REQUEST * 10^6 PEOPLE DOING IT IS IT GONNA MANAGE?
             */
            AutoPartModel autoPart = await _autoPartReader.GetAutoPartByID(model.AutoPartID);

            model.AutoPart = _mapper.Map<AutoPartModel, AutoPartViewModel>(autoPart);

            return model;
        }
	}
}
