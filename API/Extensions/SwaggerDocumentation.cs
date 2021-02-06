using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerDocumentationExtensions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
              {
                  x.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce API", Version = "v1" });
              });

            return services;
        }
        public static IApplicationBuilder AddSwaggerDocumentation(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));

            return app;
        }
    }
}