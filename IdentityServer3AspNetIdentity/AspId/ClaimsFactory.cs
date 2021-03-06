﻿using Microsoft.AspNet.Identity;

namespace IdentityServer3AspNetIdentity.AspId
{
    public class ClaimsFactory : ClaimsIdentityFactory<User, string>
    {
        public ClaimsFactory()
        {
            this.UserIdClaimType = IdentityServer3.Core.Constants.ClaimTypes.Subject;
            this.UserNameClaimType = IdentityServer3.Core.Constants.ClaimTypes.PreferredUserName;
            this.RoleClaimType = IdentityServer3.Core.Constants.ClaimTypes.Role;
        }

        public override async System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> CreateAsync(UserManager<User, string> manager, User user, string authenticationType)
        {
            var ci = await base.CreateAsync(manager, user, authenticationType);
            //if (!String.IsNullOrWhiteSpace(user.FirstName))
            //{
            //    ci.AddClaim(new Claim("given_name", user.FirstName));
            //}
            //if (!String.IsNullOrWhiteSpace(user.LastName))
            //{
            //    ci.AddClaim(new Claim("family_name", user.LastName));
            //}
            return ci;
        }
    }
}