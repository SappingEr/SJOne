using System.ComponentModel.DataAnnotations;

namespace SJOne.Models
{
    public enum Gender
    {
        [Display(Name = "Мужской")]       
        Male,
        [Display(Name = "Женский")]
        Female
    }
}
