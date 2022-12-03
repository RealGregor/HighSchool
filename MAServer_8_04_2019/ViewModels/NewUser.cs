using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    class NewUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4), MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(6), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
