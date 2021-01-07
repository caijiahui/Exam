using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace advt.Model
{
    public class LocalPasswordModel
    {
        [Required(ErrorMessage = "{0} 不能为空!")]
        [DataType(DataType.Password)]
        [Display(Name = "旧密码")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "{0} 不能为空!")]
        [StringLength(100, ErrorMessage = "{0} 必须不能小于 {2} 个字符.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "{0} 不能为空!")]
        [Display(Name = "确认密码")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "您的密码两次输入不一致!")]
        public string ConfirmPassword { get; set; }
    }
}
