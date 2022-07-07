using Microsoft.AspNetCore.Mvc;

namespace MinhaPrimeiraAPI2.Config
{
    public static class ApiConfig
    {

        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning(options =>
            {
                //Assume a versão default quando não for especificado
                options.AssumeDefaultVersionWhenUnspecified = true;
                //Definindo maior e menor versão
                options.DefaultApiVersion = new ApiVersion(majorVersion: 2, minorVersion: 0);
                //Quando consumir ele passar no header do response se estã obsoleta ou versão atual
                options.ReportApiVersions = true;

            });

            services.AddVersionedApiExplorer(options =>
            {

                options.GroupNameFormat = "'v',VVV";
                options.SubstituteApiVersionInUrl = true;


            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "Development",
                    configurePolicy: builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });
            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseMvc();
            return app;
        }

    }
}
