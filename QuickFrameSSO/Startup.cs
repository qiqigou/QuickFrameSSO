using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using QuickFrameSSO.Controllers;

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
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                /*
                 * 使用Emit覆盖原有的ClaimTypes定义
                 * (https://identityserver4.readthedocs.io/en/latest/topics/resources.html)
                 */
                options.EmitStaticAudienceClaim = true;
            })
            .AddTestUsers(TestUsers.Users)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients)
            .AddInMemoryIdentityResources(Config.IdentityResources)
            //.AddConfigurationStore(options =>
            //{
            //    /*该功能以后在扩展*/
            //    //从数据库中获取(clients, resources, CORS)
            //    options.ConfigureDbContext = builder => builder.UseSqlite(connectionString);
            //})
            .AddOperationalStore(options =>
            {
                //从数据库中获取(codes, tokens, consents)
                options.ConfigureDbContext = builder => builder.UseSqlite(connectionString);
                options.EnableTokenCleanup = true;//自动清理数据库令牌
            })
            .AddDeveloperSigningCredential();//开发时使用的秘钥(生产环境不建议使用)
            services.AddAuthentication();//添加认证服务
            services.AddControllersWithViews().AddRazorRuntimeCompilation();//添加视图的运行时编译(实时刷新视图的修改)
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
