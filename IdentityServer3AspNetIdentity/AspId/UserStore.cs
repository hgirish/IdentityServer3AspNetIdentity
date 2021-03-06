﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer3AspNetIdentity.AspId
{
    public class UserStore : UserStore<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public UserStore(Context ctx)
            : base(ctx)
        {
        }
    }
}