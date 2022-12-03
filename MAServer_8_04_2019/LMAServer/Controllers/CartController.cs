using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LMA.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMAServer.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class CartController : Controller
	{
		private readonly ICartService _cartService;

		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}
        
		//RETURNS ALL CART ITEMS THAT THE USER HAS SELECTED BEFORE
		[HttpGet]
		[Route("myItems")]
		public async Task<ActionResult<ReturnViewModel>> GetCartItems()
		{
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            return await _cartService.GetCartItems(new Guid(guid));
        }
        
		//Given group is going to be added in database
		[HttpPost]
        [Route("item")]
        public async Task<ActionResult<ReturnViewModel>> AddCartItem([FromBody]CartItemViewModel item)
		{
			Claim c = new Claim(ClaimTypes.NameIdentifier, ClaimValueTypes.String);
			var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
			if (guid == null)
				return BadRequest("Invalid Token");
            item.UserID = new Guid(guid);
			return await _cartService.AddItem(item);
		}

        [HttpPut]
        [Route("removeSome")]
        public async Task<ActionResult<ReturnViewModel>> RemoveSomeCartItems([FromBody]CartItemViewModel item) {
            Claim c = new Claim(ClaimTypes.NameIdentifier, ClaimValueTypes.String);
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            item.UserID = new Guid(guid);
            return await _cartService.RemoveSomeItems(item);
        }

        [HttpDelete]
        [Route("removeAll")]
        public async Task<ActionResult<ReturnViewModel>> RemoveAllCartItems([FromBody]CartItemViewModel item) {
            Claim c = new Claim(ClaimTypes.NameIdentifier, ClaimValueTypes.String);
            var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (guid == null)
                return BadRequest("Invalid Token");
            item.UserID = new Guid(guid);
            return await _cartService.RemoveAllItems(item);
        }
	}
}
