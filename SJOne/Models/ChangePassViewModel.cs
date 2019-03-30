using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class ChangePassViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль!")]
        public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Введите новый пароль!")]
        public string NewPassword { get; set; }

        
        [DataType(DataType.Password)]      
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Введите новый пароль повторно!")]
        public string ConfirmNewPassword { get; set; }
    }
}