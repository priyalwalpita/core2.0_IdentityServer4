using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServerTest
{
    public class Config
    {
        
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),

                new IdentityResource
                {
                    Name = "Role",
                    UserClaims = new List<string> {"Role"}
                }

            };
        }
        
        public static IEnumerable<ApiResource> GetApiResources() {
            return new List<ApiResource> {
                new ApiResource {
                    Name = "customAPI",
                    DisplayName = "Custom API",
                    Description = "Custom API Access",
                    UserClaims = new List<string> {"role"},
                    ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                    Scopes = new List<Scope> {
                        new Scope("customAPI.read"),
                        new Scope("customAPI.write")
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               
                
                new Client {
                    ClientId = "StudentMVC",
                    ClientName = "Student Example Client Application",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "customAPI.write"
                    },
                    RedirectUris = new List<string> {"http://localhost:5005/signin-oidc"},
                    PostLogoutRedirectUris = new List<string> {"http://localhost:5005"}
                },
                new Client {
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credentials Client Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {
                        new Secret("superSecretPassword".Sha256())},                         
                    AllowedScopes = new List<string> {"customAPI.read"}
                }
            };

        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "123456",
                    Username = "priyal",
                    Password = "priyal123",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Priyal Walpita"),
                        new Claim(JwtClaimTypes.GivenName, "Priyal"),
                        new Claim(JwtClaimTypes.FamilyName, "Walpita"),
                        new Claim(JwtClaimTypes.Email, "priyal@authnex.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://priyalthegeek.com"),
                        new Claim(JwtClaimTypes.Address,
                            @"{ 'street_address': '123', 'locality': 'English', 'postal_code': 123, 'country': 'Sri Lanka' }",
                            IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser
                {
                    SubjectId = "234567",
                    Username = "kanishka",
                    Password = "kanishka123",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Kanishka Gamage"),
                        new Claim(JwtClaimTypes.GivenName, "Kanishka"),
                        new Claim(JwtClaimTypes.FamilyName, "gamage"),
                        new Claim(JwtClaimTypes.Email, "kanishka@authnex.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://priyalthegeek.com"),
                        new Claim(JwtClaimTypes.Address,
                            @"{ 'street_address': '123', 'locality': 'English', 'postal_code': 123, 'country': 'Sri Lanka' }",
                            IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                
            };
        }
    }
}