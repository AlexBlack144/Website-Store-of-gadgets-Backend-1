using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Register
    {
        [Required(ErrorMessage = "User name is Required!")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "User password is Required!")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email name is Required!")]
        public string? Email { get; set; }
    }
}
