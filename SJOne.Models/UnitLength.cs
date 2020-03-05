using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public enum UnitLength: byte
    {
        [Display(Name = "Метров")]
        meters = 1,
        [Display(Name = "Километров")]
        kilometers = 2
    }
}
