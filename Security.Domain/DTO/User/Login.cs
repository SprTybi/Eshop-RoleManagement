using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Security.Domain.DTO.User
{
    public class Login
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "*")]
        public string Username { get; set; }

        [MinLength(6, ErrorMessage = "طول کلمه عبور حداقل ۶ کاراکتر است")]
        [Display(Name = "کلمه رمز")]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}

