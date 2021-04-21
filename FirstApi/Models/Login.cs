using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstApi.Models
{
    public class Login
    {
        //這支檔案不用登記到DBContext.cs裡 因為沒有需要show View

        [Required]
        [Display(Name = "電子郵件")]
        [StringLength(30, ErrorMessage = "請輸入電子郵件")]
        [EmailAddress(ErrorMessage = "not legit email format")]
        public string Email
        {
            get; set;
        }

        [Required]
        [Display(Name = "登入密碼")]
        [StringLength(50, ErrorMessage = "超過", MinimumLength = 6)]
        public string Password
        {
            get; set;
        }
    }
}