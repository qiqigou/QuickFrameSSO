using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using QuickFrameSSO.Controllers;
using System;

namespace QuickFrameSSO
{
    public class Startup
    {
        public static string BasePath => AppContext.BaseDirectory;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("MySQL");
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                //使用Emit覆盖原有的ClaimTypes定义
                //https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
                options.IssuerUri = "quickframesso";
            })
            .AddTestUsers(TestUsers.Users)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients)
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddConfigurationStore(options =>
            {
                //从数据库中获取(clients, resources, CORS)
                options.ConfigureDbContext = builder
                => builder.UseMySql(connectionString,
                sql =>
                {
                    sql.MigrationsAssembly(nameof(QuickFrameSSO));
                    sql.ServerVersion(new Version(8, 0, 22), ServerType.MySql);
                    sql.CharSetBehavior(CharSetBehavior.NeverAppend);
                });
            })
            .AddOperationalStore(options =>
            {
                //从数据库中获取(codes, tokens, consents)
                options.ConfigureDbContext = builder
                => builder.UseMySql(connectionString,
                sql =>
                {
                    sql.MigrationsAssembly(nameof(QuickFrameSSO));
                    sql.ServerVersion(new Version(8, 0, 22), ServerType.MySql);
                    sql.CharSetBehavior(CharSetBehavior.NeverAppend);
                });
                options.EnableTokenCleanup = true;//自动清理数据库令牌
            })
            .AddDeveloperSigningCredential();//开发时使用的秘钥(生产环境不建议使用)
            services.AddAuthentication();//添加认证服务
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();//添加视图的运行时编译(实时刷新视图的修改)
            services.AddControllersWithViews();//添加控制器视图
            services.Configure<CookiePolicyOptions>(options =>
            {
                //设置cookie策略(由于chrome浏览器samesite特性默认值变更,所以我们需要指定策略)
                //如果部署为https则不需要设置cookie策略
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            if (Environment.GetEnvironmentVariable("PROXY") == "1")
            {
                var options = new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                };
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
                app.UseForwardedHeaders(options);
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
