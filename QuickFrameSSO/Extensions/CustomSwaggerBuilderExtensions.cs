using System.Reflection;

namespace Microsoft.AspNetCore.Builder
{
    public static class CustomSwaggerBuilderExtensions
    {
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = $"QuickFrameSSO {Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}";
                c.SwaggerEndpoint($"/swagger/QuickFrameSSO/swagger.json", "QuickFrameSSO");
                //c.RoutePrefix = string.Empty;//设置swagger页面访问别名
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);//折叠Api
                c.DefaultModelsExpandDepth(-1);//不显示Models
            });
            return app;
        }
    }
}
