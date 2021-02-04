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

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "100",
                        Username = "system",
                        Password = "123123",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "system"),
                            new Claim(JwtClaimTypes.Role,"system"),
                            new Claim(JwtClaimTypes.GivenName, "system"),
                            new Claim(JwtClaimTypes.FamilyName, "系统用户"),
                            new Claim(JwtClaimTypes.Email, "system@email.com"),
                            new Claim(JwtClaimTypes.PhoneNumber,"110"),
                            new Claim(JwtClaimTypes.PhoneNumberVerified,"true",ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "101",
                        Username = "admin",
                        Password = "123123",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "admin"),
                            new Claim(JwtClaimTypes.Role,"admin"),
                            new Claim(JwtClaimTypes.GivenName, "admin"),
                            new Claim(JwtClaimTypes.FamilyName, "管理员"),
                            new Claim(JwtClaimTypes.Email, "admin@email.com"),
                            new Claim(JwtClaimTypes.PhoneNumber,"110"),
                            new Claim(JwtClaimTypes.PhoneNumberVerified,"true",ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "102",
                        Username = "wyl",
                        Password = "123123",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "wyl"),
                            new Claim(JwtClaimTypes.Role,JsonSerializer.Serialize(new[]{ "admin", "user" }),IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.GivenName, "wangyulin"),
                            new Claim(JwtClaimTypes.FamilyName, "王玉林"),
                            new Claim(JwtClaimTypes.Email, "wyl@email.com"),
                            new Claim(JwtClaimTypes.PhoneNumber,"110"),
                            new Claim(JwtClaimTypes.PhoneNumberVerified,"true",ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "103",
                        Username = "qiqigou",
                        Password = "123123",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "qiqigou"),
                            new Claim(JwtClaimTypes.Role,"user"),
                            new Claim(JwtClaimTypes.GivenName, "qiqigou"),
                            new Claim(JwtClaimTypes.FamilyName, "qiqigou"),
                            new Claim(JwtClaimTypes.Email, "qiqigou@email.com"),
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