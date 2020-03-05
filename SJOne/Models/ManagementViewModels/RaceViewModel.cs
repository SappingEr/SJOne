using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.ManagementViewModels
{
    public class RaceViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Введите название соревнования!")]
        [Display(Name = "Название соревнования")]        
        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        public string Name { get; set; }

        [Display(Name = "Дисциплина")]
        [Required]
        [Range(1, 10, ErrorMessage = "Укажите дисциплину!")]
        public Kind Kind { get; set; }

        [Display(Name = "Дистанция")]
        [Required(ErrorMessage = "Введите дистанцию!")]
        public string Distance { get; set; }
        
        [Required]
        [Range(1, 2, ErrorMessage = "Укажите единицу измерения!")]
        public UnitLength UnitLength { get; set; }

        [Display(Name = "Количество минут")]
        [Required(ErrorMessage = "Введите количество минут!")]
        public int CountDownTime { get; set; }

        [Display(Name = "Количество кругов")]
        [Required(ErrorMessage = "Введите количество кругов!")]
        public int LapCount { get; set; }        
       
    }
}