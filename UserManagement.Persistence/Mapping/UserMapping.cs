using System.Security.Cryptography.X509Certificates;
using NHibernate.Mapping.ByCode.Conformist;
using UserManagement.Domain;

namespace UserManagement.Persistence.Mapping
{
    public class UserMapping : ClassMapping<User>
    {
        public UserMapping()
        {
            Table("Users");
            Schema("EXS");
            Id(x => x.Id);
            Lazy(false);
            Property(x => x.Guid);
            Property(x => x.OrganizationId);
            Property(x => x.NationalCode);
            Property(x => x.Fullname);
            Property(x => x.Username);
            Property(x => x.Password);
            Property(x => x.PhoneNumber);
            Property(x => x.MobileNumber);
            Property(x => x.IsActive);
            Property(x => x.CreationDate);
            Property(x => x.RoleId);
        }
    }
}