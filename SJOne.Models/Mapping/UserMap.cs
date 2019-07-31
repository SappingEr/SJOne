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
            Map(u => u.Avatar).Length(int.MaxValue);            
            Map(u => u.Gender);
            Map(u => u.Name).Length(50);
            Map(u => u.Surname).Length(50);                        
            Map(u => u.DOB).Nullable();
            Map(u => u.RegistrationDate);
            References(u => u.SportClub).Cascade.SaveUpdate();
            References(u => u.Locality).Cascade.SaveUpdate();            
            References(u => u.Training);
            References(u => u.Group);
            References(u => u.SubGroup);
            HasMany(u => u.StartNumbersUser).Inverse();
            HasManyToMany(u => u.RacesUser).Table("User_Race")
                .ParentKeyColumn("User_id")
                .ChildKeyColumn("Race_id");
            HasManyToMany(u => u.Roles).Table("User_Role")
                .ParentKeyColumn("User_id")
                .ChildKeyColumn("Role_id").Cascade.All().Inverse();
            HasOne(u => u.Judge).Cascade.All().Constrained();
            HasOne(u => u.Trainer).Cascade.All().Constrained();
        }
    }
}
