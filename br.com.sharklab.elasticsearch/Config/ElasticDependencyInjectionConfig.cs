using br.com.sharklab.elasticsearch.Models.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using br.com.sharklab.elasticsearch.Jobs.Config;

namespace br.com.sharklab.elasticsearch.Config
{
    public static class ElasticDependencyInjectionConfig
    {
        public static IServiceCollection AddElasticServiceDI(this IServiceCollection services)
        {

            services.AddScoped<IElasticsearchService, ElasticsearchService>();

            services.AddSingleton<ConcurrentQueue<IndexingTask>>();

            services.AddScoped<ElasticSearchMiddleware>();

            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
            });

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });

            services.ConfigureOptions<ElasticBackgroundServiceSetup>();

            return services;
        }

        public static IApplicationBuilder UseElasticServices(this IApplicationBuilder app)
        {
            app.UseMiddleware<ElasticSearchMiddleware>();

            return app;
        }
    }
}