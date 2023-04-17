using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
namespace AspNetCoreIdentity.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage page,string claimName,string claimValue)
        {
            return CustomAuthorization.ValidarClaimUsuario(page.Context, claimName, claimValue);
        }

        public static string IfClaimShow(this RazorPage page,string claimName,string claimValue)
        {
            return CustomAuthorization.ValidarClaimUsuario(page.Context, claimName, claimValue) ? "" : "disabled";
        }

        public static IHtmlContent IfClaimShow(this IHtmlContent page,HttpContext context,string claimName,string claimValue)
        {
            return CustomAuthorization.ValidarClaimUsuario(context, claimName, claimValue) ? page : null;
        }
    }
}
