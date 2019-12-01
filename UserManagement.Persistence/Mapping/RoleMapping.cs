using NHibernate.Mapping.ByCode.Conformist;
using UserManagement.Domain;

namespace UserManagement.Persistence.Mapping
{
    public class RoleMapping : ClassMapping<Role>
    {
        public RoleMapping()
        {
            Table("Roles");
            Schema("EXS");
            Id(x => x.Id);
            Lazy(false);
            Property(x => x.Name);
            Property(x => x.Description);
            Property(x => x.CreationDate);
        }
    }
}