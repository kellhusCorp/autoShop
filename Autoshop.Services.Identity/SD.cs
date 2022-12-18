using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Autoshop.Services.Identity;

public static class SD
{
    public const string Admin = "Admin";

    public const string Customer = "Customer";

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("Autoshop", "Autoshop Server"),
            new ApiScope("read", "Read your data"),
            new ApiScope("write", "write your data"),
            new ApiScope("delete", "delete your data")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "client",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "read",
                    "write",
                    "profile"
                }
            },
            new()
            {
                ClientId = "Autoshop",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris =
                {
                    "https://localhost:7251/signin-oidc"
                },
                PostLogoutRedirectUris =
                {
                    "https://localhost:7251/signout-callback-oidc"
                },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "Autoshop"
                }
            }
        };
}