using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class RegisterViewModel
    {
        [StringLength(50)]
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите Логин")]
        public string Login { get; set; }        

        [StringLength(20)]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [StringLength(20)]
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль повторно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}