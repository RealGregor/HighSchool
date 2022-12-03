using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LMAServer.Controllers
{
	[Produces("application/json")]
	[Route("api/Auth")]
	public class AuthController : Controller
	{

		private readonly ILoginService _authService;

		public AuthController(ILoginService authService)
		{
			_authService = authService;
		}

		[HttpPost]
		public async Task<ActionResult<ReturnViewModel>> Token()
		{
			var header = Request.Headers["Authorization"];
			if (header.ToString().StartsWith("Basic"))
			{
				var credValue = header.ToString().Substring("Basic ".Length).Trim();
				var usernameAndPassword = Encoding.UTF8.GetString(Convert.FromBase64String(credValue)); //username:password
				var usernameAndPass = usernameAndPassword.Split(":");

				return await _authService.Authenticate(usernameAndPass[0], usernameAndPass[1]);
			}
			{
				ReturnViewModel result = new ReturnViewModel();
				result.Ok = false;
				result.Result.Messages.Add(new MessageViewModel(16));
				return result;
			}
		}
	}
}
