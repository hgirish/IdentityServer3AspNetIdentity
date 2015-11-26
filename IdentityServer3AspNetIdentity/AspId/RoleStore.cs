using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer3AspNetIdentity.AspId
{
    public class RoleStore : RoleStore<Role>
    {
        public RoleStore(Context ctx)
            : base(ctx)
        {
        }
    }
}