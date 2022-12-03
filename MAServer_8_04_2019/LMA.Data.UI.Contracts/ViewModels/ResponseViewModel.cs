using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels
{
	public class ResponseViewModel
	{
		public object Object { get; set; }

		public List<MessageViewModel> Messages { get; set; }

		public ResponseViewModel()
		{
			Messages = new List<MessageViewModel>();
		}

	}
}
