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
            Map(u => u.Password).Length(350);
            Map(u => u.Status);
            Map(u => u.Avatar).Length(int.MaxValue);            
            Map(u => u.Gender);
            Map(u => u.Name).Length(50);
            Map(u => u.Surname).Length(50);
            Map(u => u.City).Length(50);
            Map(u => u.Club).Length(50);
            Map(u => u.DOB).Nullable();
            Map(u => u.RegistrationDate);
            References(u => u.Race);
            References(u => u.Judge);
            HasMany(u => u.StartNumbers);
            HasManyToMany(u => u.Roles).Table("User_Role")
                .ParentKeyColumn("User_id")
                .ChildKeyColumn("Role_id");

        }
    }
}
