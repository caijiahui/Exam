using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace advt.Model
{
    public class RegisterModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "{0} 不能为空!")]
        public string UserName { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "{0} 不能为空!")]
        public byte sex { get; set; }

        [Required(ErrorMessage = "{0} 不能为空!")]
        [StringLength(100, ErrorMessage = "{0} 密码长度不能小于 {2} 个字符.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "您输入的确认密码和密码不一致.")]
        [Required(ErrorMessage = "{0} 不能为空!")]
        public string ConfirmPassword { get; set; }
        public string email { get; set; }
    }
}
