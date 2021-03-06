﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJOne.Models
{
    public class Race
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int StartNumberCount { get; set; }

        public virtual string Distance { get; set; }

        public virtual UnitLength UnitLength { get; set; }

        public virtual Kind Kind { get; set; }

        public virtual int LapCount { get; set; }

        public virtual int CountdownTime { get; set; }        

        [DataType(DataType.Time)]
        public virtual DateTime? StartTime { get; set; }

        [DataType(DataType.Time)]
        public virtual DateTime? FinishTime { get; set; }

        public virtual User MainJudgeRace { get; set; }

        public virtual bool AgeFromEvent { get; set; }

        public virtual IList<AgeGroup> AgeGroups { get; set; } = new List<AgeGroup>(); 

        public virtual IList<StartNumber> StartNumbersRace { get; set; } = new List<StartNumber>();       

        public virtual IList<User> JudgesRace { get; set; } = new List<User>();

        public virtual SportEvent SportEvent { get; set; }
    }
}
