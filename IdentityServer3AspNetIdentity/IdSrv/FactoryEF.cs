using System.Collections.Generic;
using System.Linq;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.EntityFramework;

namespace IdentityServer3AspNetIdentity.IdSrv
{
    class FactoryEf
    {
        public static IdentityServerServiceFactory Configure(string connString, string schema)
        {
            var efConfig = new EntityFrameworkServiceOptions
            {
                ConnectionString = connString,
                Schema = schema
            };

            ConfigureClients(Clients.Get(), efConfig);
            ConfigureScopes(Scopes.Get(), efConfig);

            var factory = new IdentityServerServiceFactory();

            factory.RegisterConfigurationServices(efConfig);
            factory.RegisterOperationalServices(efConfig);


            return factory;
        }

        private static void ConfigureScopes(IEnumerable<Scope> scopes, EntityFrameworkServiceOptions options)
        {
            using (var db = new ScopeConfigurationDbContext(options.ConnectionString, options.Schema))
            {
                //if (!db.Scopes.Any())
                //{
                    foreach (var s in scopes)
                    {
                        if (db.Scopes.Any(x=>x.Name == s.Name))
                        {
                            // scope exists
                        }
                        else
                        {
                             var e = s.ToEntity();
                            db.Scopes.Add(e);
                        }
                       
                    }
                    db.SaveChanges();
               // }
            }
        }

        private static void ConfigureClients(IEnumerable<Client> clients, EntityFrameworkServiceOptions options)
        {
            using (var db = new ClientConfigurationDbContext(options.ConnectionString, options.Schema))
            {
                //if (!db.Clients.Any())
                //{
                    foreach (var c in clients)
                    {
                        if (!db.Clients.Any(x=>x.ClientId == c.ClientId))
                        {
                            var e = c.ToEntity();
                        db.Clients.Add(e);
                        }
                        
                    }
                    db.SaveChanges();
               // }
            }
        }

    }
}