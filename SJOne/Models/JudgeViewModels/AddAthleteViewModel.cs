﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJOne.Models.JudgeViewModels
{
    public class AddAthleteViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Укажите пол")]
        public string Gender { get; set; }

        [StringLength(50, ErrorMessage = "Превышено количество допустимых символов(не более 50)")]
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите Имя")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Превышено количество допустимых символов(не более 50)")]
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите Фамилию")]
        public string Surname { get; set; }

        [Display(Name = "Регион")]
        public IEnumerable<SelectListItem> Regions { get; set; }

        public string NewPlace { get; set; }

        public IEnumerable<SelectListItem> Locality { get; set; }        

        [Display(Name = "Клуб")]
        public IEnumerable<SelectListItem> Clubs { get; set; }        

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Укажите дату рождения")]
        public DateTime? DOB { get; set; }
    }
}