using LMA.Data.UI.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ClientResponseModels
{
    public class ClientResponseViewModel<T> where T : class
    {
		public T Object { get; set; }

		public List<MessageViewModel> Messages { get; set; }
	}
}
