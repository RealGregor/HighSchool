using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
