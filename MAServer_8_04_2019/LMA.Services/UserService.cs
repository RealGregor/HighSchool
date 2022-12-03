using AutoMapper;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMA.Services.Contracts;
using System.Linq;
using MoreLinq;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LMA.Data.UI.ViewModels.ViewModels.Order;

namespace LMA.Services
{
	public class UserService : IUserService
	{
		private readonly IUserReader<UserModel> _ReadService;
		private readonly IWriter<UserModel> _WriteService;
		private readonly IMapper _mapper;
		private readonly IAutoPartReader<AutoPartModel> _AutoPartReadService;
		private readonly IWriter<OrderModel> _CollabWriteService;
        private readonly IEmployeeReader<EmployeeModel> _EmployeesReadService;
        private readonly IWriter<EmployeeModel> _EmployeesWriteService;

        public UserService(IUserReader<UserModel> ReadService,
							IWriter<UserModel> WriteService,
							IMapper mapper,
							IAutoPartReader<AutoPartModel> TenantReadService,
							IWriter<OrderModel> CollabWriteService,
                            IEmployeeReader<EmployeeModel> EmployeesReadService,
                            IWriter<EmployeeModel> EmployeesWriteService
			)
		{
			_ReadService = ReadService;
			_WriteService = WriteService;
			_mapper = mapper;
			_AutoPartReadService = TenantReadService;
			_CollabWriteService = CollabWriteService;
            _EmployeesReadService = EmployeesReadService;
            _EmployeesWriteService = EmployeesWriteService;
		}

		//Add new user by calling UserWriter
		public async Task<ReturnViewModel> CreateUser(CreateUserViewModel userNew)
		{
			ReturnViewModel result = new ReturnViewModel();
			//mapping from userNew -> user (UserModel)
			UserModel user = _mapper.Map<CreateUserViewModel, UserModel>(userNew);
			user.TimeCreated = DateTime.Now;

			//get user, that we are trying to add, from database
			UserModel userFromDatabase = await _ReadService.GetUser(user.Email);
			
			user.Role = ""; //HAS TO BE CHANGED
			user.EmailConfirmed = true;


			//CollaboratorModel collab = new CollaboratorModel();
			//Check if user already exists
			if (userFromDatabase == null)//we add user to database
            {
				//collab.Id = Guid.NewGuid();
				//collab.Notifications = false;
				//collab.Favourite = false;
				//collab.Tenant_Id = user.TenantId;

				await _WriteService.Create(user);
				//collab.User_Id = user.Id;
				//await _CollabWriteService.Create(collab);

				result.Result.Messages.Add(new MessageViewModel(3));
				return result;
			}
			else
			{
				result.Ok = false;
				result.Result.Messages.Add(new MessageViewModel(2));
				return result;
			}
		}

		//Return id of user with given email
		public async Task<Guid> GetUserId(string email)
		{
			UserModel user = await _ReadService.GetUser(email);
			if (user == null)
				return Guid.Empty;
			return user.Id;
		}

		//Get UserViewModel od user with given email
		public async Task<ReturnViewModel> GetUser(Guid User_Id, string email)
		{

			ReturnViewModel result = new ReturnViewModel();
			//get user by email
			UserModel user = await _ReadService.GetUser(email);
			//if user is null then return empty UserViewModel
			if (user == null)
			{
				result.Ok = false;
				result.Result.Messages.Add(new MessageViewModel(4));
				return result;
			}

			//Mapping from user -> result
			UserViewModel userForReturn = _mapper.Map<UserModel, UserViewModel>(user);
			//set Guid to empty, because others should not see it

			result.Result.Object = userForReturn;
			result.Result.Messages.Add(new MessageViewModel(3));
			return result;
		}

		//Get password of user with given email
		public async Task<string> GetUserPassword(string email)
		{
			UserModel user = await _ReadService.GetUser(email);
			if (user == null)
				return "";
			return user.Password;
		}

		//Get all data of user with given id
		public async Task<UserViewModel> GetUserById(Guid id)
		{
			UserModel user = await _ReadService.GetUserById(id);
			//CHeck if user does not exist
			if (user == null)
				return new UserViewModel();
			//Else, mapping from UserModel -> UserViewModel
			UserViewModel result = _mapper.Map<UserModel, UserViewModel>(user);
			result.Id = Guid.Empty;
			return result;
		}
        
		//Call UserWriter to update data of given user
		public async Task<ReturnViewModel> Update(Guid User_Id, ChangeUserViewModel user)
		{
			ReturnViewModel result = new ReturnViewModel();
			UserModel UpdatedUser = await _ReadService.GetUserById(User_Id);
			
			if (UpdatedUser == null)
			{
				result.Ok = false;
				result.Result.Messages.Add(new MessageViewModel(6));
				return result;
			}


			if (user.Name != null)
				UpdatedUser.Name = user.Name;
			if (user.Surname != null)
				UpdatedUser.Surname = user.Surname;
            if (user.Address != null)
                UpdatedUser.Address = user.Surname;
            if (user.AddressNumber != null)
                UpdatedUser.AddressNumber = user.Surname;
            if (user.Country != null)
                UpdatedUser.Country = user.Surname;
            if (user.PhoneNumber != null)
				UpdatedUser.PhoneNumber = user.PhoneNumber;
			if (user.ProfilePicture != null)
				UpdatedUser.ProfilePicture = Convert.FromBase64String(user.ProfilePicture);

			await _WriteService.Update(UpdatedUser);

			UserViewModel res = _mapper.Map<UserModel, UserViewModel>(UpdatedUser);

			result.Result.Object = user;
			result.Result.Messages.Add(new MessageViewModel(3));
			return result;
		}

		//Delete user with given id, by checking the passwords credibility
		public async Task<ReturnViewModel> Delete(Guid User_Id, string password)
		{
			ReturnViewModel result = new ReturnViewModel();
			UserModel user = await _ReadService.GetUserById(User_Id);
			if (user.Password == password)
			{
				result.Result.Object = await _WriteService.Delete(User_Id);
				result.Result.Messages.Add(new MessageViewModel(3));
				return result;
			}
			else
			{
				result.Ok = false;
				result.Result.Messages.Add(new MessageViewModel(10));
				return result;
			}
		}

		//Change password of user with given id
		public async Task<ReturnViewModel> ChangePassword(Guid User_Id, ChangePasswordViewModel password)
		{
			ReturnViewModel result = new ReturnViewModel();
			UserModel UpdatedUser = await _ReadService.GetUserById(User_Id);

			if (UpdatedUser.Password != password.ConfirmPassword)
			{
				result.Ok = false;
				result.Result.Messages.Add(new MessageViewModel(10));
				return result;
			}

			UpdatedUser.Password = password.Password;
			await _WriteService.Update(UpdatedUser);

			result.Result.Object = UpdatedUser;
			result.Result.Messages.Add(new MessageViewModel(11));
			return result;
		}
    }
}
