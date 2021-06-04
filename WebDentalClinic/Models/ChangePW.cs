using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDentalClinic.Models
{
    public class ChangePW
    {

        public int Id { get; set; }

        [Display(Name ="Mật khẩu cũ")]
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]

        public string PasswordOld { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string PasswordNew { get; set; }
        [Display(Name = "Xác nhận mật khẩu ")]
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]
        [Compare("PasswordNew", ErrorMessage = "Sai mật Khẩu, Vui Lòng Nhập Lại")]
        public string ConfirmPassword { get; set; }


    }
}