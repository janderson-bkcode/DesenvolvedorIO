using DevIO.Business.Intefaces;
using DevIO.Business.Services;
using DevIO.Data.Context;
using DevIO.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
//using Swashbuckle.AspNetCore.SwaggerGen;

namespace DevIO.api.Config
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<MeuDbContext>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorService, FornecedorService>();
           // services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }
    }
}
