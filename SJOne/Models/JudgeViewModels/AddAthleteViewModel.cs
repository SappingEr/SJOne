using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SJOne.Extensions;

namespace SJOne.Models.JudgeViewModels
{
    public class AddAthleteViewModel
    {
        public long Id { get; set; }

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

        [StringLength(12, ErrorMessage = "Превышено количество допустимых символов(не более 12).")]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\+7[0-9]{10}", ErrorMessage = "Введите номер без пробелов.")]
        public string PhoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Превышено количество допустимых символов(не более 50).")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Заполните поле Email правильно.")]
        public string Email { get; set; }

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