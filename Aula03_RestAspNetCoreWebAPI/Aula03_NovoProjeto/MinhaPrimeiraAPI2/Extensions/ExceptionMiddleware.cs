using System.Net;

namespace MinhaPrimeiraAPI2.Extensions
  { /// <summary>
    /// Classe de configuraçao de Middeware para gerar erro 500 ao haver Exception
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //Tenta dar um next
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //Chama o metodo
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static /*async*/ Task HandleExceptionAsync(HttpContext context, Exception ex)


        {
            //Versão aula 08 modulo 03 do Eduardo Pires que usa o Elmah para log
            // await exception.ShiÁsync(context); => método de extensão do Elomah.IO
            //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //Devolve 500
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Task.CompletedTask;
        }
    }
}
