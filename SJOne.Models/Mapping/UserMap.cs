using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.UserName).Length(50);
            Map(u => u.Email).Length(50);
            Map(u => u.PhoneNumber).Length(12);
            Map(u => u.Password).Length(350);
            Map(u => u.Status);
            Map(u => u.Gender);
            Map(u => u.Avatar).Length(int.MaxValue);          
            Map(u => u.Name).Length(50);
            Map(u => u.Surname).Length(50);                        
            Map(u => u.DOB).Nullable();
            Map(u => u.RegistrationDate);
            HasMany(u => u.StartNumbersUser).Inverse();
            HasMany(u => u.MainJudgeRaces).Inverse();
            HasMany(u => u.HandTimingsJudge);
            HasMany(u => u.AutoTimingsJudge);
            HasMany(u => u.StartNumbersJudge);
            HasMany(u => u.Protocols);
            HasManyToMany(u => u.JudgeRaces).Table("Judge_Race")
                .ParentKeyColumn("Judge_id")
                .ChildKeyColumn("Race_id");
            References(u => u.SportClub).Cascade.SaveUpdate();
            References(u => u.Locality).Cascade.SaveUpdate();            
            HasManyToMany(u => u.Roles).Table("User_Role")
                .ParentKeyColumn("User_id")
                .ChildKeyColumn("Role_id");            
        }
    }
}
