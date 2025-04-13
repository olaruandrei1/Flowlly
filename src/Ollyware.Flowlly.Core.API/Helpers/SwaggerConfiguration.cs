using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Ollyware.Flowlly.Core.API.Helpers;

public static class SwaggerConfiguration
{
    public static IServiceCollection RegisterSwagger(this IServiceCollection services)
    => services.AddEndpointsApiExplorer()
               .AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Title = "Personal Template",
                       Description = "Personal Template",
                       Contact = new OpenApiContact()
                       {
                           Name = "Andrei",
                           Email = "olaruandrei828@gmail.com"
                       },
                       Version = "v1"
                   });
                   var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetEntryAssembly().GetName().Name}.xml");
                   c.IncludeXmlComments(filePath);
                   c.UseInlineDefinitionsForEnums();
               });

    public static WebApplication ConfigureSwagger(this WebApplication application)
    {
        if (application.Environment.IsDevelopment())
            application.UseSwagger();
        else
            application.UseSwagger(c =>
            {
                var config = application.Services.GetService<IConfiguration>();
                var serverUrl = config?.GetValue<string>("ServerPrefixUrl") ?? string.Empty;//if Load Balancer is used

                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = [new() { Url = $"/{serverUrl}" }];
                });
            });

        application.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("v1/swagger.json", "PersonalTemplate");
        });

        return application;
    }
}
