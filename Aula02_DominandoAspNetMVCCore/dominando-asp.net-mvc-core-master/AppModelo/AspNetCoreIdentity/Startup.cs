using KissLog;
using KissLog.Apis.v1.Listeners;
using KissLog.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetCoreIdentity.Config;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Diagnostics;
using AspNetCoreIdentity.Extensions;

namespace AspNetCoreIdentity
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostingEnvironment)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(hostingEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true, true)
				.AddEnvironmentVariables();

			if (hostingEnvironment.IsProduction())
			{
				builder.AddUserSecrets<Startup>();
			}

			Configuration = builder.Build();

		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<ILogger>((context) =>
			{
				return Logger.Factory.Get();
			});

			services.AddIdentityCOnfig(Configuration);
			services.AddAutohrizationConfig();
			services.ResolveDepencencies();
			services.AddScoped<AuditoriaFilter>();

			services.AddMvc(options =>
			{
				options.Filters.Add(typeof(AuditoriaFilter));
			});
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/erro/500");
				app.UseStatusCodePagesWithRedirects("/erro/{0}");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			// app.UseKissLogMiddleware() must to be referenced after app.UseAuthentication(), app.UseSession()
			app.UseKissLogMiddleware(options =>
			{
				ConfigureKissLog(options);
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		private void ConfigureKissLog(IOptionsBuilder options)
		{
			// register KissLog.net cloud listener
			options.Listeners.Add(new KissLogApiListener(new KissLog.Apis.v1.Auth.Application(
				Configuration["KissLog.OrganizationId"],    //  "8d0cae97-67fe-41a6-a067-401e7fe553e7"
				Configuration["KissLog.ApplicationId"])     //  "4ef4034f-8810-4598-9c4b-14f459097d2e"
			)
			{
				ApiUrl = Configuration["KissLog.ApiUrl"]    //  "https://api.kisslog.net"
			});

			// optional KissLog configuration
			options.Options
				.AppendExceptionDetails((Exception ex) =>
				{
					StringBuilder sb = new StringBuilder();

					if (ex is System.NullReferenceException nullRefException)
					{
						sb.AppendLine("Important: check for null references");
					}

					return sb.ToString();
				});

			// KissLog internal logs
			options.InternalLog = (message) =>
			{
				Debug.WriteLine(message);
			};
		}
	}
}
