using Microsoft.AspNet.Identity;

namespace IdentityServer3AspNetIdentity.AspId
{
    public class RoleManager : RoleManager<Role>
    {
        public RoleManager(RoleStore store)
            : base(store)
        {
        }
    }
}