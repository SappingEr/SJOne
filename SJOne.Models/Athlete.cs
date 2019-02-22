using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Athlete: User
    {
        public virtual byte[] Avatar { get; set; }

        public virtual int StartNumber { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string City { get; set; }

        public virtual string Club { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime DOB { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime RegistrationDate { get; set; }

        public virtual IList<Race> Races { get; set; }
    }
}
