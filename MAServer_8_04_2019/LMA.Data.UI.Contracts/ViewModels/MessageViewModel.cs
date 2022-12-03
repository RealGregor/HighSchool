using LMA.Data.UI.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels
{
    public class MessageViewModel
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public MessageViewModel()
        {
            this.Code = 0;
            SetMessage();
        }

        public MessageViewModel(int _Code)
        {
            this.Code = _Code;
            SetMessage();
        }

		public MessageViewModel(string message)
		{
			this.Code = -1;
			this.Message = message;
		}

		public void SetMessage()
        {
            if (MessageCodes.dictionary.ContainsKey(Code))
            {
                this.Message = MessageCodes.dictionary[Code];
            }
            else
            {
                this.Message = "Message not defined";
            }
        }
    }
}
