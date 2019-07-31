﻿using System;
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

        public virtual string PhoneNumber { get; set; }

        public virtual string Password { get; set; }

        public virtual Status Status { get; set; }

        public virtual byte[] Avatar { get; set; }

        public virtual Gender Gender { get; set; }

        [FastSearch]
        public virtual string Name { get; set; }

        [FastSearch]
        public virtual string Surname { get; set; }
        
        public virtual Locality Locality { get; set; }       

        public virtual SportClub SportClub { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? DOB { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime RegistrationDate { get; set; }

        public virtual IList<StartNumber> StartNumbersUser { get; set; } = new List<StartNumber>();

        public virtual IList<TrainerTiming> TrainerTimings { get; set; } = new List<TrainerTiming>();

        public virtual IList<Role> Roles { get; set; } = new List<Role>();

        public virtual IList<Race> RacesUser { get; set; } = new List<Race>();

        public virtual Training Training { get; set; }

        public virtual Group Group { get; set; }

        public virtual SubGroup SubGroup { get; set; }

        private Trainer trainer;

        public virtual Trainer Trainer { get { return trainer ?? (trainer = new Trainer()); } set { trainer = value; } }

        private Judge judge;

        public virtual Judge Judge { get { return judge ?? (judge = new Judge()); } set { judge = value; } }


    }
}
