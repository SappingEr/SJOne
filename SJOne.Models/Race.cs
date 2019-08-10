using System.Collections.Generic;

namespace SJOne.Models
{
    public class Race
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int StartNumberCount { get; set; }

        public virtual decimal Distance { get; set; }

        public virtual int LapCount { get; set; }

        public virtual Judge MainJudgeRace { get; set; }

        public virtual IList<AgeGroup> AgeGroups { get; set; } = new List<AgeGroup>(); 

        public virtual IList<StartNumber> StartNumbersRace { get; set; } = new List<StartNumber>();       

        public virtual IList<Judge> JudgesRace { get; set; } = new List<Judge>();

        public virtual SportEvent SportEvent { get; set; }
    }
}
