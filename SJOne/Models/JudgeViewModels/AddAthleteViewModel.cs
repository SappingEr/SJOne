using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.JudgeViewModels
{
    public class AddAthleteViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Укажите пол")]
        public string Gender { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите Имя")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите Фамилию")]
        public string Surname { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Введите город")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        [Display(Name = "Клуб")]
        public string Club { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Укажите дату рождения")]
        public DateTime? DOB { get; set; }
    }
}