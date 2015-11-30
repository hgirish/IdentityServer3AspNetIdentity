using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace IdentityServer3AspNetIdentity.IdSrv
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                Enabled = true,
                ClientName = "MVC Client",
                ClientId = "mvc",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    "https://localhost:44301/"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "https://localhost:44301/"
                },
                AllowAccessToAllScopes = true
            },
                new Client
                {
                    ClientName = "Katana Hybrid Client",
                    Enabled = true,
                    ClientId = "katanaclient",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,
                    //AllowedScopes = new List<string>
                    //{
                    //    Constants.StandardScopes.OpenId,
                    //    Constants.StandardScopes.Profile,
                    //    Constants.StandardScopes.Email,
                    //    Constants.StandardScopes.Roles,
                    //    Constants.StandardScopes.OfflineAccess,
                    //    "read",
                    //    "write"
                    //},
                    ClientUri = "https://localhost:44302",
                    RequireConsent = false,
                    AccessTokenType = AccessTokenType.Reference,
                    RedirectUris = new List<string> {"https://localhost:44302/" },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44302/"
                    }
                }

            };
        }
    }
}