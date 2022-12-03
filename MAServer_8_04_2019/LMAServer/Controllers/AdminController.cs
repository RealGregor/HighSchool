using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMAServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ReturnViewModel>> Token() {
            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic")) {
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndPassword = Encoding.UTF8.GetString(Convert.FromBase64String(credValue)); //username:password
                var usernameAndPass = usernameAndPassword.Split(":");

                return await _adminService.Authenticate(usernameAndPass[0], usernameAndPass[1]);
            }
            {
                ReturnViewModel result = new ReturnViewModel();
                result.Ok = false;
                result.Result.Messages.Add(new MessageViewModel(16));
                return result;
            }
        }

        //Get all notifications
        [HttpGet]
        public async Task<ActionResult<ReturnViewModel>> GetNotifications()
        {
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            return null;// await _NotificationService.GetNotifications(new Guid(guid));
        }

        [HttpDelete]
        public async Task<ActionResult<ReturnViewModel>> DeleteNotifications([FromBody] List<AdminViewModel> list)
        {
            return null;// await _NotificationService.DeleteNotifications(list);
        }

        //Change collaborator favourite settings
        [HttpPost]
        public async Task<ActionResult<ReturnViewModel>> AddNotifications([FromBody] AdminViewModel model)
        {
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            return null;// await _NotificationService.AddNotification(new Guid(guid), model);
        }

    }
}
