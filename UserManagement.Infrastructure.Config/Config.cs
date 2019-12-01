using System.Collections.Generic;
using IdentityServer4.Models;
using static IdentityModel.JwtClaimTypes;

namespace UserManagement.Infrastructure.Config
{
    public class Config
    {
        public IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Exchange_Api", "exchange service")
                {
                    UserClaims =
                    {
                        Id,
                        Role,
                        Name,
                        "name"
                    }
                }
            };
        }

        public IEnumerable<Client> Clients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "PishtazAutomation",
                    ClientName = "PishtazAutomation WinUi",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowAccessTokensViaBrowser = true,
                    IdentityTokenLifetime = 14400,
                    AuthorizationCodeLifetime = 14400,
                    AccessTokenLifetime = 14400,
                    AllowedScopes =
                    {
                        "openid",
                        "profile",
                        "Exchange_Api"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    AllowOfflineAccess = true,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }

        public List<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}