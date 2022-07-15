using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DevIO.api.Config
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

           // services.AddScoped<APIDbContext>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }
    }
}
