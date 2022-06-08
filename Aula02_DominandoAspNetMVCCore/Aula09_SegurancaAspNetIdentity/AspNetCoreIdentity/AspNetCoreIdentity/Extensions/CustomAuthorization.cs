using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Security.Claims;

namespace AspNetCoreIdentity.Extensions
{
    //Aula 09.06 Customização de Claims
    public class CustomAuthorization
    {
        public static bool ValidarClaimUsuario(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }

    }

    public class ClaimsAuthorizeAtrribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAtrribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        } 
    }

    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        readonly Claim _claim;


        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(values: new { area = "Identity", page = "/Account/Login", ReturnUrl = context.HttpContext.Request.Path.ToString() }));
                return;
            }


            if (!CustomAuthorization.ValidarClaimUsuario(context.HttpContext, _claim.Type, _claim.Value))

                //caso não tiver a validação da claim, o acesso é negado com resultado
                context.Result = new ForbidResult();
        }
    }
}

