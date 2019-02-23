﻿using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class AthleteMap: SubclassMap<Athlete>
    {
        public AthleteMap()
        {
            Map(a => a.Avatar).Length(int.MaxValue);
            Map(a => a.StartNumber);
            Map(a => a.Gender);
            Map(a => a.Name).Length(50);
            Map(a => a.Surname).Length(50);
            Map(a => a.City).Length(50);
            Map(a => a.Club).Length(50);
            Map(a => a.DOB);
            Map(a => a.RegistrationDate);            
            HasManyToMany(a =>a.Races).Table("Race_Athlete")
                .ParentKeyColumn("Race_Id")
                .ChildKeyColumn("Athlete_Id");
        }
    }
}
