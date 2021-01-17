using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace QuickFrameSSO
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Address(),
            new IdentityResources.Email(),
            new IdentityResources.Phone(),
            new IdentityResource
            {
                Name = "role",
                DisplayName = "角色信息",
                Description = "获取角色信息",
                Emphasize = true,
                UserClaims = { JwtClaimTypes.Role },
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("quickframe")
        };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("quickframe_api","quickframe项目",new string[]{ JwtClaimTypes.Role ,JwtClaimTypes.Name })
            {
                Scopes = { "quickframe" },
                ApiSecrets = { new Secret("quickframe_api_secrets".Sha256())},
            },
        };
        /// <summary>
        /// 注册客户端
        /// </summary>
        /// <value></value>
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //简化模式(Swagger文档)
                new Client
                {
                    ClientId = "test",
                    ClientName = "测试客户端",
                    AllowedGrantTypes = GrantTypes.ImplicitAndClientCredentials,
                    RequireConsent = true,
                    ClientSecrets =
                    {
                        new Secret("test".Sha256()),
                    },
                    AllowOfflineAccess = true,
                    AllowRememberConsent = true,//允许记住对客户端的授权
                    RedirectUris =
                    {
                        "http://localhost:8000/oauth2-redirect.html",
                        "https://localhost:8000/oauth2-redirect.html",
                        "http://localhost/oauth2-redirect.html",
                        "https://onlyoned.com:9000/oauth2-redirect.html",
                        "https://www.onlyoned.com:9000/oauth2-redirect.html",
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:8000",
                        "https://localhost:8000",
                        "http://localhost",
                        "https://onlyoned.com:9000",
                        "https://www.onlyoned.com:9000",

                    },
                    AccessTokenLifetime = 3600 * 24,
                    AllowedCorsOrigins =
                    {
                        "http://localhost:8000",
                        "https://localhost:8000",
                        "http://localhost",
                        "https://onlyoned.com:9000",
                        "https://www.onlyoned.com:9000"
                    },
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        "quickframe"
                    },
                },
                //密码模式(自动测试程序)
                new Client
                {
                    ClientId = "quickframe_test",
                    ClientName = "自动测试程序",
                    ClientSecrets = {new Secret("quickframe_test".Sha256())},
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AccessTokenLifetime = 600,
                    AllowedScopes =
                    {
                        "quickframe"
                    }
                },
                //授权码模式(正式环境)
                new Client
                {
                    ClientId = "quickframe_jsclient",
                    ClientName = "智星商场js客户端",
                    RequireClientSecret = false,
                    RequireConsent = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowRememberConsent = true,//允许记住对客户端的授权
                    RedirectUris = { "http://localhost:3343/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:3343/index.html" },
                    AccessTokenLifetime = 600,
                    AllowedCorsOrigins = { "http://localhost:3343" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        JwtClaimTypes.Role,
                        "quickframe"
                    }
                },
            };
    }
}
