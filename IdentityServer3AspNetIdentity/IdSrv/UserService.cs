using IdentityServer3.AspNetIdentity;
using IdentityServer3AspNetIdentity.AspId;

namespace IdentityServer3AspNetIdentity.IdSrv
{
    public class UserService : AspNetIdentityUserService<User, string>
    {
        public UserService(UserManager userMgr)
          : base(userMgr)
        {
        }
    }
}