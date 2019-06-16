using FluentNHibernate.Mapping;

namespace SJOne.Models.Mapping
{
    public class RoleMap: ClassMap<Role>
    {
        public RoleMap()
        {
            Id(r => r.Id).GeneratedBy.Identity();
            Map(r => r.Name).Length(50);
            HasManyToMany(r => r.Users).Table("User_Role")
               .ParentKeyColumn("Role_id")
               .ChildKeyColumn("User_id").Cascade.SaveUpdate();
        }
    }
}
