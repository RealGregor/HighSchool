using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels
{
	public class ReturnViewModel
	{
		public bool Ok { get; set; }

		public ResponseViewModel Result { get; set; }

		public ReturnViewModel()
		{
			Ok = true;
			Result = new ResponseViewModel();
		}
	}
}
