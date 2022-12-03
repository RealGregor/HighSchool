using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMA.Data.UI.ViewModels.ViewModels
{
    public class AdminAuthenticationResponseViewModel
    {
        public string Token { get; set; }

        public AdminViewModel Admin { get; set; }

        public AdminAuthenticationResponseViewModel() {
            Token = null;
        }
    }
}
