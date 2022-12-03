using LMA.Data.UI.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.Filters
{
	public class ResponseFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var s = context.Result;
			if (s is ObjectResult)
			{
				var k = (ObjectResult)s;
				var value = k.Value;
				if (value is ReturnViewModel)
				{
					var response = (ReturnViewModel)value;

					if (response.Ok)
						context.Result = new OkObjectResult(response.Result);
					else
						context.Result = new BadRequestObjectResult(response.Result);
				}
			}



			//IActionResult s = context.Result;
			//if (typeof(ObjectResult) == s )
			//{
			//				var k = (ObjectResult)s;
			//				var data = k.Value;
			//				if(data == typeof(ReturnViewModel))
			//				{
			//								k.Value = 
			//				}

			//}
		}
	}
}
