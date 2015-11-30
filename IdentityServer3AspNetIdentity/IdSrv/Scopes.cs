using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityServer3AspNetIdentity.IdSrv
{
    static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new Scope[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email,
                StandardScopes.OfflineAccess,
                StandardScopes.Roles,
                new Scope
                {
                    Name = "read",
                    DisplayName = "Read data",
                    Type = ScopeType.Resource,
                    Emphasize = false,
                },
                new Scope
                {
                    Name = "write",
                    DisplayName = "Write data",
                    Type = ScopeType.Resource,
                    Emphasize = true,
                },
                new Scope
                {
                    Name = "forbidden",
                    DisplayName = "Forbidden scope",
                    Type = ScopeType.Resource,
                    Emphasize = true
                }
             };
        }
    }
}