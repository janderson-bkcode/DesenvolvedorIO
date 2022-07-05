using MinhaPrimeiraAPI2.Data;


namespace MinhaPrimeiraAPI2.Models
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<APIDbContext>();

            return services;
        }
    }

}