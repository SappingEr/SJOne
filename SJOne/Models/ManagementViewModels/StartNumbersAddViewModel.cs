using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.ManagementViewModels
{
    public class StartNumbersAddViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Начало нумерации")]
        [Required(ErrorMessage = "Введите номер!")]
        public int? InitialStartNumber { get; set; }

        [Display(Name = "Конец нумерации")]        
        public int? FinalStartNumber { get; set; }        

        [Display(Name = "От")]        
        public int? From { get; set; }

        [Display(Name = "До")]        
        public int? To { get; set; }

        [Display(Name = "Номера")]        
        [RegularExpression(@"[0-9,.]+", ErrorMessage = "Введите номера через запятую, без пробелов!")]
        public string ExNumbers { get; set; }
    }
}