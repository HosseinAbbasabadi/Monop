using System;
using Framework.Core;

namespace UserManagement.Application
{
    public interface IUserManagementApplication
    {
        OperationResult Register(RegisterUser command);
        OperationResult Login(string username, string password);
    }
}