using System.Collections.Generic;
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

                AllowAccessToAllScopes = true
            }

            };
        }
    }
}