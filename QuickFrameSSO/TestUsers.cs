using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

namespace QuickFrameSSO.Controllers
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "背面",
                    locality = "太空",
                    postal_code = 110,
                    country = "月球"
                };

                string[] roles = { "admin", "user" };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "001",
                        Username = "admin",
                        Password = "123123",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "admin"),
                            new Claim(JwtClaimTypes.Role,JsonSerializer.Serialize(roles),IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.GivenName, "admin"),
                            new Claim(JwtClaimTypes.FamilyName, "管理员"),
                            new Claim(JwtClaimTypes.Email, "admin@email.com"),
                            new Claim(JwtClaimTypes.PhoneNumber,"110"),
                            new Claim(JwtClaimTypes.PhoneNumberVerified,"true",ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}