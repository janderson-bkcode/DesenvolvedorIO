using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinhaPrimeiraAPI2.Config
{
        public static class SwaggerConfig
    {

        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

               // c.OperationFilter<SwaggerDefaultValues>();
                //c.SwaggerDoc(name:"v1",new OpenApiInfo { Title="Minha API 2",Version="v1"});

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Fornecedores",
                    Description = "Api para Fornecedores",
                    Contact = new OpenApiContact
                    {
                        Name = "SelfPay",
                        Email = String.Empty,
                        Url = new Uri("https://selfpay.com.br/"),
                    }

                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app,IApiVersionDescriptionProvider provider)
        {

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(url:$"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
            return app;

        }
    }

        public class SwaggerDefaultValues : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var apiDescription = context.ApiDescription;

                operation.Deprecated = apiDescription.IsDeprecated();

                if (operation.Parameters == null)
                {
                    return;
                }

                foreach (var parameter in operation.Parameters.OfType<OpenApiParameter>())
                {
                    var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                    if (parameter.Description == null)
                    {
                        parameter.Description = description.ModelMetadata?.Description;
                    }
                    //if (parameter.Default == null)
                    //{
                    //    parameter.Default = description.DefaultValue;
                    //}

                    parameter.Required |= description.IsRequired;
                }
            }
        }


        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            readonly IApiVersionDescriptionProvider provider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;
            public void Configure(SwaggerGenOptions options)
            {
                //Pega todas as minhas versões da Api e adiciona uma doc para cada uma delas
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
            }

            static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
            {
                var info = new OpenApiInfo()
                {
                    Title = "Api -  desenvolvedor IO",
                    Version = description.ApiVersion.ToString(),
                    Description = "Esta API faz´parte do curso REST com ASP.NET Core WebAPI",
                    Contact = new OpenApiContact() { Name = "Eduardo Pires", Email = "contato@dev.IO" },
                    TermsOfService = new Uri("https://opensource.org/license/MIT"),
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
                };

                if (description.IsDeprecated)
                {
                    info.Description += "Está versão está obsoleta";
                }

                return info;
            }
        }
}

