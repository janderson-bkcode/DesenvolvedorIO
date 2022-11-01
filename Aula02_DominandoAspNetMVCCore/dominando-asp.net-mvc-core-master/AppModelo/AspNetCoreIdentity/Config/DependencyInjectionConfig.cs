using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetCoreIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Config;

namespace AspNetCoreIdentity.Config
{
	public static class DependencyInjectionConfig
	{
		public static IServiceCollection ResolveDepencencies(this IServiceCollection services)
		{
			services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();
			return services;
		}

		public static IServiceCollection AddIdentityCOnfig(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AspNetCoreIdentityContext>(options =>
					options.UseSqlServer(
						configuration.GetConnectionString("AspNetCoreIdentityContextConnection")));

			services.AddDefaultIdentity<IdentityUser>()
				.AddRoles<IdentityRole>()
				.AddDefaultUI()
				.AddEntityFrameworkStores<AspNetCoreIdentityContext>();
			return services;
		}
	}
}
