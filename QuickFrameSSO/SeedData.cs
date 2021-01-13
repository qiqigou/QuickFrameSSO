using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuickFrameSSO
{
    public class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            if (environment.IsDevelopment())
            {
                using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
                var persistedContext = scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
                var configContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedData>>();
                await EnsureSeedData(logger, configContext);
            }
        }

        private static async Task EnsureSeedData(ILogger<SeedData> logger, ConfigurationDbContext context)
        {
            logger.LogInformation("开始移除配置数据");
            await context.Database.ExecuteSqlRawAsync("delete from Clients where 1=1");
            await context.Database.ExecuteSqlRawAsync("delete from IdentityResources where 1=1");
            await context.Database.ExecuteSqlRawAsync("delete from ApiScopes where 1=1");
            await context.Database.ExecuteSqlRawAsync("delete from ApiResources where 1=1");
            logger.LogInformation("配置数据移除完成");

            var clients = Config.Clients.Select(x => x.ToEntity());
            var identityresources = Config.IdentityResources.Select(x => x.ToEntity());
            var scopes = Config.ApiScopes.Select(x => x.ToEntity());
            var apiresources = Config.ApiResources.Select(x => x.ToEntity());

            logger.LogInformation("开始写入配置数据");
            context.Clients.AddRange(clients);
            context.IdentityResources.AddRange(identityresources);
            context.ApiScopes.AddRange(scopes);
            context.ApiResources.AddRange(apiresources);
            context.SaveChanges();
            logger.LogInformation("配置数据写入完成");
        }
    }
}
