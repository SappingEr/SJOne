﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJOne.Models
{
    public class SportEvent
    {
        public virtual long Id { get; set; }

        public virtual bool Show { get; set; }

        public virtual string EventName { get; set; }

        public virtual string Description { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime EventDate { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime EndRegDate { get; set; }

        public virtual Locality Locality { get; set; }

        public virtual IList<EventFile> EventFiles { get; set; } = new List<EventFile>();

        public virtual IList<EventPhoto> EventPhotos { get; set; } = new List<EventPhoto>();

        public virtual IList<Tag> Tags { get; set; } = new List<Tag>();

        public virtual IList<Race> RacesEvent { get; set; } = new List<Race>();
    }
}
