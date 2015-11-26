using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;

namespace IdentityServer3AspNetIdentity.IdSrv
{
    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>{
                new InMemoryUser{
                    Subject = "1",
                    Username = "bob",
                    Password = "secret",
                    Claims = new Claim[]{
                        new Claim(Constants.ClaimTypes.Name, "Bob"),
                        new Claim(Constants.ClaimTypes.Role, "Bar"),
                    }
                },
                new InMemoryUser{
                    Subject = "2",
                    Username = "alice",
                    Password = "alice",
                    Claims = new Claim[]{
                        new Claim(Constants.ClaimTypes.Name, "Alice"),
                        new Claim(Constants.ClaimTypes.Role, "Foo"),
                    }
                }
            };
        }
    }
}