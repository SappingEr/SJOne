using System.ComponentModel.DataAnnotations;

namespace SJOne.Models
{
    public enum Gender
    {
        [Display(Name = "Мужской")]       
        Male = 1,
        [Display(Name = "Женский")]
        Female = 2
    }
}
