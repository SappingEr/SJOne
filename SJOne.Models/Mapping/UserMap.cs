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
            HasManyToMany(u => u.Roles).Table("User_Role")
                .ParentKeyColumn("User_id")
                .ChildKeyColumn("Role_id");

        }
    }
}
