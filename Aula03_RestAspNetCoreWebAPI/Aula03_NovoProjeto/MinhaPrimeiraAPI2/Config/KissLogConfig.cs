using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MinhaPrimeiraAPI2.Config
{/// <summary>
/// Classe configuração Kisslog dotnet <=5.0
/// </summary>
    public static class KissLogConfig
    {

        public static IServiceCollection AddKissLogConfig5(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            // Optional. Register IKLogger if you use KissLog.IKLogger instead of Microsoft.Extensions.Logging.ILogger<>
            services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());

            services.AddLogging(logging =>
            {
                logging.AddKissLog(options =>
                {
                    options.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null)
                            return args.DefaultValue;

                        string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });

            return services;
        }

        public static IApplicationBuilder UseKissLogConfig(this IApplicationBuilder app)
        {
           /* app.UseKissLogMiddleware(options => ConfigureKissLog(options, (configuration);*/
            return app;
        }

        public static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            KissLogConfiguration.Listeners.Add(new RequestLogsApiListener(new Application(
                configuration["KissLog.OrganizationId"],    //  "58237e8b-71db-4ac7-94d5-75221d84bfb9"
                configuration["KissLog.ApplicationId"])     //  "41d14b78-4aca-4243-9b3e-698395712dd2"
            )
            {
                ApiUrl = configuration["KissLog.ApiUrl"]    //  "https://api.kisslog.net"
            });
        }


    }
}
