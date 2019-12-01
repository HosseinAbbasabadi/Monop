using Framework.Nhibernate;
using NHibernate;
using UserManagement.Domain;

namespace UserManagement.Persistence
{
    public class UserManagementRepository : BaseRepository<int, User>, IUserManagementRepository
    {
        public UserManagementRepository(ISession session) : base(session)
        {
        }
    }
}