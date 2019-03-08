using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class EditUserViewModel
    {
        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Логин")]        
        public string Login { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Введите Логин")]
        public string Email { get; set; }

        
        [Display(Name = "Пол")]        
        public Gender Gender { get; set; }

        [StringLength(50)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [StringLength(50)]
        [Display(Name = "Город")]
        public string City { get; set; }

        [StringLength(50)]
        [Display(Name = "Логин")]
        public string Club { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime DOB { get; set; }
    }
}