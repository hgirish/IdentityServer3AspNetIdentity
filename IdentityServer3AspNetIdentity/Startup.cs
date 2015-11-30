using System.IO;
using IdentityServer3AspNetIdentity.IdSrv;
using Owin;
using Serilog;
using IdentityServer3.Core.Configuration;

namespace IdentityServer3AspNetIdentity
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data");
            if (!string.IsNullOrWhiteSpace(mappedPath))
            {
                if (!Directory.Exists(mappedPath))
                {
                    Directory.CreateDirectory(mappedPath);
                }
            }
            string logFile = Path.Combine(mappedPath, "idsrvlog.txt");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(logFile)
                .CreateLogger();

            app.Map("/core", coreApp =>
            {
                var idSvrFactory = FactoryEf.Configure("AspId","IdSrv");
                idSvrFactory.ConfigureUserService("AspId");

                var options = new IdentityServerOptions
                {
                    SiteName = "IdentityServer3 - UserService-AspNetIdentity",
                    SigningCertificate = Certificate.Get(),
                    Factory = idSvrFactory,
                    AuthenticationOptions = new AuthenticationOptions()
                    {
                        IdentityProviders = ConfigureAdditionalIdentityProviders,
                        EnablePostSignOutAutoRedirect = true
                    }
                };

                coreApp.UseIdentityServer(options);
            });
        }

        private void ConfigureAdditionalIdentityProviders(IAppBuilder app, string signInAsType)
        {
            // provide for Google, Facebook, Twitter etc.
        }
    }
}