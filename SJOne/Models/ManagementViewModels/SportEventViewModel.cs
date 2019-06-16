using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.ManagementViewModels
{
    public class SportEventViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите Название!")]
        [StringLength(150, ErrorMessage = "Превышено колическтво допустимых символов(не более 150)")]
        public string EventName { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Введите дату события!")]
        public DateTime EventDate { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}