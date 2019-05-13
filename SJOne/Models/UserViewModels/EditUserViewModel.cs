using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJOne.Models
{
    public class EditUserViewModel
    {
        public long Id { get; set; }
        
        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        public string Login { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Клуб")]
        public string Club { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
    }
}