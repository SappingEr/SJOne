using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJOne.Models
{
    public class Training
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        [DataType(DataType.Time)]
        public virtual DateTime TrainingTime { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime TrainigDate { get; set; }

        public virtual TimeSpan Duration { get; set; }

        public virtual IList<User> UsersTrainig { get; set; }

        public virtual IList<Trainer> TrainersTrainig { get; set; }


    }
}
