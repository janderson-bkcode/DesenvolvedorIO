using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace MinhaPrimeiraAPI2.Config
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection AddHealthCheckConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //Aqui adicionamos o HealthChecks e a Configuração HealthCheck com o SQL Server
            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString(name: "DefaultConnection"), name: "Banco");

            return services;
        }
        public static IServiceCollection AddHealthCheckUIConfig(this IServiceCollection services)
        {
            //Configurando a interface gráfica e o armazenamento do histórico 
            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(5); //define o intervalo que será disparado a verificação dos serviços
                options.MaximumHistoryEntriesPerEndpoint(10); // define a quantidade máxima de registros permitidos no histórico

                // options.AddHealthCheckEndpoint("API com Health Checks", "/api/hc"); Outra forma de adicionar um endpoint para ser monitorado
            }).AddInMemoryStorage(); //Aqui adicionamos o banco em memória
            return services;
        }
        public static IApplicationBuilder UseHealthCheckConfig(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/hc", new HealthCheckOptions //Aqui ativamos o serviço e o caminho da chamada
            {
                Predicate = p => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            return app;
        } public static IApplicationBuilder UseHealthCheckUIConfig(this IApplicationBuilder app)
        {
            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/Dashboard";
                options.AddCustomStylesheet(@"Estilo\HealthCheck.css");
            });
            return app;
        }
    }
}
