using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3AspNetIdentity.AspId;


namespace IdentityServer3AspNetIdentity.IdSrv
{
    public static class UserServiceExtensions
    {
        public static void ConfigureUserService(this IdentityServerServiceFactory factory, string connString)
        {
            factory.UserService = new Registration<IUserService, UserService>();
            factory.Register(new Registration<UserManager>());
            factory.Register(new Registration<UserStore>());
            factory.Register(new Registration<Context>(resolver => new Context(connString)));
        }
    }
}