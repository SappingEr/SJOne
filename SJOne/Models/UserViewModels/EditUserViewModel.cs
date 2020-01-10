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
        [Display(Name = "Пол")]
        [Required]
        [Range(1, 2, ErrorMessage = "Выберите пол.")]
        public Gender Gender { get; set; }

        [StringLength(50, ErrorMessage = "Превышено количество допустимых символов(не более 50).")]
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите Имя.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Превышено количество допустимых символов(не более 50).")]
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите Фамилию.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Выберите регион.")]
        [Display(Name = "Регион")]
        public long RegionId { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }

        [Required(ErrorMessage = "Выберите населённый пункт.")]
        [Display(Name = "Населённый пункт")]
        public long LocalityId { get; set; }
        public IEnumerable<SelectListItem> Localities { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Укажите дату рождения.")]
        public DateTime? DOB { get; set; }
    }
}