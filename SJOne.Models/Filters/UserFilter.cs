using System.ComponentModel.DataAnnotations;

namespace SJOne.Models.Filters
{
    public class UserFilter: BaseFilter
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        public DateTime DOB { get; set; }

        public DateRange Date { get; set; }
    }
}

