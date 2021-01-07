using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace advt.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "{0} 不能为空!")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} 不能为空!")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "密码保存时间?")]
        public int? CookieTime { get; set; }
    }
}
