using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SJOne.Models.Repositories;

namespace SJOne.Models
{
    public class User : IUser<long>
    {
        public virtual long Id { get; set; }

        [FastSearch]
        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual Status Status { get; set; }

        public virtual byte[] Avatar { get; set; }

        public virtual Gender Gender { get; set; }

        [FastSearch]
        public virtual string Name { get; set; }

        [FastSearch]
        public virtual string Surname { get; set; }

        public virtual string City { get; set; }

        public virtual string Club { get; set; }

        public virtual IList<Race> Races { get; set; } = new List<Race>();

        public virtual Judge Judge { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? DOB { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime RegistrationDate { get; set; }

        public virtual IList<StartNumber> StartNumbersU { get; set; } = new List<StartNumber>();

        public virtual IList<Role> Roles { get; set; } = new List<Role>();

    }
}
