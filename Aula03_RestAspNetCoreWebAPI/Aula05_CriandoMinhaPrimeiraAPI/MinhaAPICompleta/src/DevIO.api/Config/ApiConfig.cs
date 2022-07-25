using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.api.Config
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            return services;
        }
        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
