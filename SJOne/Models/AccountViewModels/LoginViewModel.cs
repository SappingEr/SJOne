using System.ComponentModel.DataAnnotations;

namespace SJOne.Models
{
    public class LoginViewModel
    {
        [StringLength(50)]
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите Логин")]
        public string Login { get; set; }

        [StringLength(50)]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }        

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}