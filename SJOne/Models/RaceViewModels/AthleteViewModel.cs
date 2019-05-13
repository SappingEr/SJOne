using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.RaceViewModels
{
    public class AthleteViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Введите имя!")]
        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию!")]
        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите название города!")]
        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Введите название клуба!")]
        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        public string Club { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения!")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }       
        
    }
}