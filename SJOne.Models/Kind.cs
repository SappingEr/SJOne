using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public enum Kind : byte
    {
        [Display(Name = "Бег")]
        Run = 1,
        [Display(Name = "Велосипед")]
        Bicycle,
        [Display(Name = "Плавание")]
        Swim,
        [Display(Name = "Обратный отсчёт")]
        Countdown
    }
}
