using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Order;
using LMA.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMAServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : Controller {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService) {
            _OrderService = OrderService;
        }

        //Get all collaborators of user
        [HttpGet]
        [Route("myOrders")]
        public async Task<ActionResult<ReturnViewModel>> GetOrders()
        {
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            return await _OrderService.GetOrders(new Guid(guid));
        }

        [HttpGet]
        [Route("ordersOnThisDate")]
        public async Task<ActionResult<ReturnViewModel>> GetOrdersOnThisDate([FromHeader] string Date) {
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            return await _OrderService.GetOrdersOnThisDate(new Guid(guid), DateTime.Parse(Date));
        }
        
        [HttpPost]
        [Route("addOrder")]
        public async Task<ActionResult<ReturnViewModel>> AddOrder([FromBody] AddOrderViewModel order) {
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            return await _OrderService.AddOrder(new Guid(guid), order);
        }
    }
}
