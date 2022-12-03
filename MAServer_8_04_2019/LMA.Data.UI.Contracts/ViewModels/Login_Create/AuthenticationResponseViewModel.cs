using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels
{
    public class AuthenticationResponseViewModel
    {
        public string Token { get; set; }

        public UserViewModel User { get; set; }

        public AuthenticationResponseViewModel() {
            Token = null;
        }
    }
}
