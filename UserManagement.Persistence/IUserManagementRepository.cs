using System;
using Framework_Domain;
using UserManagement.Domain;

namespace UserManagement.Persistence
{
    public interface IUserManagementRepository: IRepository<int, User>
    {
    }
}
