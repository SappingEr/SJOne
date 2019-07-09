using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJOne.Models
{
    public class SportEvent
    {
        public virtual long Id { get; set; }

        public virtual string EventName { get; set; }

        public virtual string Description { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime EventDate { get; set; }

        public virtual Locality EventCity { get; set; }

        public virtual IList<EventFile> EventFiles { get; set; }

        public virtual IList<EventPhoto> EventPhotos { get; set; }

        public virtual IList<Tag> Tags { get; set; }

        public virtual IList<Race> RacesEvent { get; set; }
    }
}
