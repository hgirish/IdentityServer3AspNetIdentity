using Microsoft.AspNet.Identity;

namespace IdentityServer3AspNetIdentity.AspId
{
    public class UserManager : UserManager<User, string>
    {
        public UserManager(UserStore store)
            : base(store)
        {
            this.ClaimsIdentityFactory = new ClaimsFactory();
        }
    }
}