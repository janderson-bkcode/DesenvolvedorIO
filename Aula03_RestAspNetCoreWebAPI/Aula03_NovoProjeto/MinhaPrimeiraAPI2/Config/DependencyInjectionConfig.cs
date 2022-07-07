using Microsoft.Extensions.Options;
using MinhaPrimeiraAPI2.Config;
using MinhaPrimeiraAPI2.Data;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinhaPrimeiraAPI2.Models
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<APIDbContext>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }
    }

}