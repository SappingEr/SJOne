using System;
using System.ComponentModel.DataAnnotations;

namespace SJOne.Models.Filters
{
    public class UserFilter: BaseFilter
    {
        public string UserName { get; set; }

        public string Email { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public Gender? Gender { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        public DateRange Date { get; set; }
    }
}

