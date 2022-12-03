using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Services.Contracts
{
	public interface IUserService
	{
		Task<ReturnViewModel> CreateUser(CreateUserViewModel userNew);

		Task<Guid> GetUserId(string email);

		Task<ReturnViewModel> Update(Guid User_Id, ChangeUserViewModel user);

		Task<ReturnViewModel> Delete(Guid User_Id, string password);

		Task<ReturnViewModel> GetUser(Guid id, string email);

		Task<string> GetUserPassword(string email);

		Task<ReturnViewModel> ChangePassword(Guid User_Id, ChangePasswordViewModel password);
	}
}
