using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Framework.Core;
using Framework.Identity;
using UserManagement.Domain;
using UserManagement.Persistence;

namespace UserManagement.Application
{
    public class UserManagementApplication : IUserManagementApplication
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementApplication(IUserManagementRepository userManagementRepository, IPasswordHasher passwordHasher)
        {
            _userManagementRepository = userManagementRepository;
            _passwordHasher = passwordHasher;
        }

        public OperationResult Register(RegisterUser command)
        {
            var result = new OperationResult("Users", "Register");
            try
            {
                if (_userManagementRepository.IsDuplicated(x => x.Username == command.Username))
                {
                    return result.Failed(ApplicationMessages.UserAlreadyRegistered);
                }

                if (_userManagementRepository.IsDuplicated(x => x.NationalCode == command.NationalCode))
                {
                    return result.Failed(ApplicationMessages.NationalCodeAlreadyRegistered);
                }

                var hashedPassword = _passwordHasher.Hash(command.Password);
                var user = new User(Guid.NewGuid(), command.OrganizationId, command.NationalCode, command.Fullname,
                    command.Username, hashedPassword, command.PhoneNumber, command.MobileNumber, command.RoleId);
                _userManagementRepository.BeginTran();
                _userManagementRepository.Create(user);
                _userManagementRepository.CommitTran();
                return result.Succeeded(ApplicationMessages.Success);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                _userManagementRepository.RoleBack();
                return result.Failed(ApplicationMessages.SystemFailure);
            }
        }

        public OperationResult Login(string username, string password)
        {
            var result = new OperationResult("Users", "Login");
            try
            {
                var hashedPassword = _passwordHasher.Hash(password);
                var user = _userManagementRepository
                    .Get(x => x.Username == username && x.Password == hashedPassword && x.IsActive)
                    .FirstOrDefault();
                if (user == null)
                {
                    return result.Failed(ApplicationMessages.WrongUsernameOrPassword);
                }

                var claims = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("role", user.RoleId),
                    new KeyValuePair<string, object>("username", user.Username)
                };
                result.FeedResult(user.Id, claims);
                return result.Succeeded(ApplicationMessages.Success);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return result.Failed(ApplicationMessages.SystemFailure);
            }
        }
    }
}