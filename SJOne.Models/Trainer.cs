using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJOne.Models
{
    public class Trainer
    {
        public virtual long Id { get; set; }

        public virtual User User { get; set; }

        public virtual string School { get; set; }

        public virtual Training TrainingTr { get; set; }

        public virtual IList<Group> Groups { get; set; } = new List<Group>();

        public virtual IList<TrainerTiming> TrainerTimingsTr { get; set; } = new List<TrainerTiming>();

        
    }
}
