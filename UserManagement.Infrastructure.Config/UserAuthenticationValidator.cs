using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using UserManagement.Application;

namespace UserManagement.Infrastructure.Config
{
    public class UserAuthenticationValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserManagementApplication _userManagementApplication;

        public UserAuthenticationValidator(IUserManagementApplication userManagementApplication)
        {
            _userManagementApplication = userManagementApplication;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var loginResult = _userManagementApplication.Login(context.UserName, context.Password);
            if (loginResult.IsSuccessful())
            {
                var userRoleId = loginResult.GetData().First(x => x.Key == "role").Value.ToString();
                var username = loginResult.GetData().First(x => x.Key == "username").Value.ToString();
                context.Result = new GrantValidationResult(loginResult.GetRecordId().ToString(), "bearer", DateTime.Now,
                    new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, userRoleId),
                        new Claim(ClaimTypes.NameIdentifier, username),
                    });
                return Task.FromResult(context.Result);
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, loginResult.GetMessage());
            return Task.FromResult(context.Result);
        }
    }
}