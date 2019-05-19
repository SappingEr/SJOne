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
        public int InitialStartNumber { get; set; }

        [Display(Name = "Количество стартовых номеров")]
        [Required(ErrorMessage = "Введите количество стартовых номеров!")]
        public int StartNumberCount { get; set; }
    }
}