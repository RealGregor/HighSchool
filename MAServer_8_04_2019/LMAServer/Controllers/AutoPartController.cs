using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LMA.Data.Contracts.Readers;
using LMA.Data.Contracts.Writers;
using LMA.Data.Models;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.UI.ViewModels.ViewModels.AutoPart;
using LMA.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMAServer.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class AutoPartController : Controller
	{
		private readonly IAutoPartService _AutoPartService;

		public AutoPartController(IAutoPartService AutoPartService)
		{
			_AutoPartService = AutoPartService;
		}

		[HttpGet]
        [Route("subCategory")]
        public async Task<ActionResult<ReturnViewModel>> GetSubCategoryAutoParts([FromHeader]string subCategory)
		{
            var result = await _AutoPartService.GetSubCategoryAutoParts(subCategory);
            return result;
        }


        [HttpGet]
        [Route("category")]
        public async Task<ActionResult<ReturnViewModel>> GetCategoryAutoParts([FromHeader]string category) {
            category = System.Web.HttpUtility.UrlDecode(category);

            var result = await _AutoPartService.GetCategoryAutoParts(category);
            return result;
        }

        [HttpPost]
        [Route("categoryFilter")]
        public async Task<ActionResult<ReturnViewModel>> GetSuitableCategoryAutoParts([FromBody] AutoPartFiltersViewModel filters) {
            decimal pMin = 0;
            decimal pMax = 0;
            try {
                pMin = Convert.ToDecimal(filters.priceMin);
                pMax = Convert.ToDecimal(filters.priceMax);
            } catch (Exception ex) {
                pMin = 0;
                pMax = decimal.MaxValue;
            }

            var result = await _AutoPartService.GetSuitableCategoryAutoParts(filters.Category, filters.TechnicalDetails, pMin, pMax);
            return result;
        }


  //      [HttpGet]
		//[Route("settings/company")]
		//public async Task<ActionResult<ReturnViewModel>> GetTenantTimeParametersOfUser()
		//{
		//	var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
		//	if (guid == null)
		//		return BadRequest("Invalid Token");
		//	return await _AutoPartService.GetTenantTimeParametersOfUser(new Guid(guid));

		//}

        [HttpGet]
        [Route("byID")]
        public async Task<ActionResult<ReturnViewModel>> GetAutoPartByID([FromHeader]string autoPartID) {
            Guid ID = Guid.Empty;
            try {
                ID = new Guid(autoPartID);
            } catch (Exception ex) {}

            return await _AutoPartService.GetAutoPartByID(ID);
        }

  //      [HttpGet]
		//[Route("settings/personal")]
		//public async Task<ActionResult<ReturnViewModel>> GetCustomTimeParametersOfUser()
		//{
		//	var guid = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
		//	if (guid == null)
		//		return BadRequest("Invalid Token");
		//	return await _AutoPartService.GetCustomTimeParametersOfUser(new Guid(guid));

		//}

		[HttpPost]
        [Route("addAutoPart")]
        public async Task<ActionResult<ReturnViewModel>> AddAutoPart([FromBody] AutoPartViewModel autoPart)
		{
            return await _AutoPartService.AddAutoPart(autoPart);
		}

		[HttpDelete]
		public async Task<ActionResult<ReturnViewModel>> DeleteAutoPart([FromBody] DeleteAutoPartViewModel deleteAutoPart)
		{
            var adminID = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (adminID == null)
                return BadRequest("Invalid Token");
            return await _AutoPartService.DeleteAutoPart(new Guid(adminID), deleteAutoPart);
		}

		[HttpPut]
		public async Task<ActionResult<ReturnViewModel>> UpdateAutoPart([FromBody] ChangeAutoPartViewModel changeAutoPart)
		{
            var adminID = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (adminID == null)
                return BadRequest("Invalid Token");
            return await _AutoPartService.UpdateAutoPart(new Guid(adminID), changeAutoPart);
        }
	}
}
