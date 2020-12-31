using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuickFrameSSO;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomSwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("QuickFrameSSO", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "QuickFrameSSO"
                });
                options.IncludeXmlComments(Path.Combine(Startup.BasePath, $"QuickFrameSSO.xml"), true);
                options.SchemaFilter<SchemaFilter>();
            });
        }
        /// <summary>
        /// 设置swagger默认值
        /// </summary>
        public class SchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (!context.Type.IsClass || context.Type == typeof(string) || !context.Type.IsPublic || context.Type.IsArray) return;
                var obj = Activator.CreateInstance(context.Type);
                _ = (from sc in schema.Properties
                     join co in context.Type.GetProperties() on sc.Key.ToLower() equals co.Name.ToLower()
                     select sc.Value.Example = co.GetValue(obj) != null ? OpenApiAnyFactory.CreateFor(sc.Value, co.GetValue(obj)) : sc.Value.Example).ToList();
            }
        }
    }
}
