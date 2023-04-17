using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor;
using DevIO.UI.Site.Modulos.Vendas.Data;
using DevIO.UI.Site.Servicos;

namespace DevIO.UI.Site
{
    public class Startup
    {
        //This method gest called by runTime . Use this method to add services to the container.
        //For more information on how to configure your application,visit http://go.microsoft.com/fwlink/?/LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Chamando o serviço do MVC
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //Aula 06 Areas
            // Caso você queira mudar o nome da pasta Areas para outro nome , neste caso mudamos para Mòdulos
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add(item: "/Modulos/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add(item: "/Modulos/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add(item: "Views/Shared/{0}.cshtml");
            });

            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddTransient<IOperacaoTransient, Operacao>();
            services.AddScoped<IOperacaoScoped, Operacao>();
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(id:Guid.Empty));

            services.AddTransient<OperacaoService>();
        }

        //This method gets called by the runTime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Com essa linha podemos usar os arquivos Jquery e Boostrap estáticos que estão no wwwroot estaticos para o browser reconhecer
            app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //Aplicando a rota usando o serviço do MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(name: "AreaProdutos", areaName: "Produtos", template: "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
                routes.MapAreaRoute(name: "AreaVendas", areaName: "Vendas", template: "Vendas/{controller=Pedidos}/{action=Index}/{id?}");
            });

        }
    }
}
