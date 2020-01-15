using System;
using System.ComponentModel.DataAnnotations;

namespace SJOne.Models.UserViewModels
{
    public class EditUserViewModel
    {
        public long Id { get; set; }

        [StringLength(50, ErrorMessage = "Превышено количество допустимых символов(не более 50).")]
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите Имя.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Превышено количество допустимых символов(не более 50).")]
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите Фамилию.")]
        public string Surname { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Укажите дату рождения.")]
        public DateTime? DOB { get; set; }
    }
}