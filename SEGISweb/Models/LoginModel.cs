using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEGISweb.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "يجب ادخال اسم المستخدم")]
        public string Username { set; get; }

        [Required(ErrorMessage = "يجب ادخال كلمه السر")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}