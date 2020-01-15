using System.ComponentModel.DataAnnotations;

namespace SJOne.Models.UserViewModels
{
    public class GenderViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Пол")]
        [Required]
        [Range(1, 2, ErrorMessage = "Выберите пол.")]
        public Gender Gender { get; set; }
    }
}