using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.UI.Site
{
    public class Startup
    {
        //This method gest called by runTime . Use this method to add services to the container.
        //For more information on how to configure your application,visit http://go.microsoft.com/fwlink/?/LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        //This method gets called by the runTime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //Aplicando a rota
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
