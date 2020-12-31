using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Linq;

namespace QuickFrameSSO
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddOperationalDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlite(connectionString, sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
            });
            services.AddConfigurationDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlite(connectionString, sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
            });

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var persistedContext = scope.ServiceProvider.GetService<PersistedGrantDbContext>();
            persistedContext.Database.Migrate();

            var configContext = scope.ServiceProvider.GetService<ConfigurationDbContext>();
            configContext.Database.Migrate();
            EnsureSeedData(configContext);
        }

        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            context.Clients.RemoveRange(context.Clients.ToList());
            Log.Debug("添加客户端");
            foreach (var client in Config.Clients.ToList())
            {
                context.Clients.Add(client.ToEntity());
            }
            context.SaveChanges();

            context.IdentityResources.RemoveRange(context.IdentityResources.ToList());
            Log.Debug("添加Identity资源");
            foreach (var resource in Config.IdentityResources.ToList())
            {
                context.IdentityResources.Add(resource.ToEntity());
            }
            context.SaveChanges();

            context.ApiScopes.RemoveRange(context.ApiScopes.ToList());
            Log.Debug("添加API范围资源");
            foreach (var scope in Config.ApiScopes.ToList())
            {
                context.ApiScopes.Add(scope.ToEntity());
            }

            context.ApiResources.RemoveRange(context.ApiResources.ToList());
            Log.Debug("添加API资源");
            foreach (var resource in Config.ApiResources.ToList())
            {
                context.ApiResources.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }
    }
}
