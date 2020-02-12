using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.UserViewModels
{
    public class ChangePassViewModel
    {
        public long Id { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль!")]
        [Display(Name ="Пароль")]
        public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Введите новый пароль!")]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        
        [DataType(DataType.Password)]      
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Введите новый пароль повторно!")]
        [Display(Name = "Подтвердить новый пароль")]
        public string ConfirmNewPassword { get; set; }
    }
}