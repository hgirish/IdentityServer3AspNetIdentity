using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer3AspNetIdentity.AspId
{
    public class Context : IdentityDbContext<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public Context(string connString)
            : base(connString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("IdSrv");
            base.OnModelCreating(modelBuilder);
        }
    }
}