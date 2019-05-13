using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.RaceViewModels
{
    public class RaceViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Название соревнования")]        
        [StringLength(50, ErrorMessage = "Превышено колическтво допустимых символов(не более 50)")]
        public string Name { get; set; }

        [Display(Name = "Дистанция")]
        [Required(ErrorMessage = "Введите дистанцию!")]
        public double Distance { get; set; }

        [Display(Name = "Количество кругов")]
        [Required(ErrorMessage = "Введите количество кругов!")]
        public int LapCount { get; set; }        
       
    }
}