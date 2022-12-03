using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.ComponentModel.DataAnnotations;
using LMA.Data.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using LMA.Data.UI.ViewModels.ViewModels;
using System.Windows.Forms;
using LMA.Services.Contracts;
using System.Security.Claims;
using System.Text;
using LMA.Data.UI.ViewModels.ViewModels.Employee;

namespace LMAServer.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;


		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		//User with given email is returned (if user with email do not exists, empty user is returned)
		[HttpGet]
		public async Task<ActionResult<ReturnViewModel>> GetUser([FromHeader]string Email)
		{
			var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
			if (guid == null)
				return BadRequest("Invalid Token");
			return await _userService.GetUser(new Guid(guid), Email);
		}
        
		//Given user is going to be added in database
		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult<ReturnViewModel>> CreateUser([FromBody]CreateUserViewModel user)
		{
			return await _userService.CreateUser(user);
		}

		//Given user is going to be updated in database
		[HttpPut]
		public async Task<ActionResult<ReturnViewModel>> UpdateUser([FromBody]ChangeUserViewModel model)
		{
			var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
			if (guid == null)
				return BadRequest("Invalid Token");
			return await _userService.Update(new Guid(guid), model);
		}

		//Change password
		[HttpPut]
		[Route("password")]
		public async Task<ActionResult<ReturnViewModel>> ChangePassword([FromBody]ChangePasswordViewModel model)
		{
			var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
			if (guid == null)
				return BadRequest("Invalid Token");
			return await _userService.ChangePassword(new Guid(guid), model);
		}

		//User with given id is going to bo deleted from database
		[HttpDelete]
		[AllowAnonymous]
		public async Task<ActionResult<ReturnViewModel>> Delete([FromBody]DeleteUserViewModel model)
		{
			var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
			if (guid == null)
				return BadRequest("Invalid Token");
			return await _userService.Delete(new Guid(guid), model.Password);
		}

	}
}
