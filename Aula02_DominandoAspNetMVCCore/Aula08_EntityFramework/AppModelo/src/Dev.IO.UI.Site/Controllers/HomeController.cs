using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DevIO.UI.Site.Servicos;

namespace DevIO.UI.Site.Controllers
{
    public class HomeController : Controller


    {
        //Recebendo duas injencões de Dependencia

        public OperacaoService OperacaoService { get; }

        public OperacaoService OperacaoService2 { get; set; }

        public HomeController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            OperacaoService = operacaoService;
            OperacaoService2 = operacaoService2;
        }
        [Route("")]
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id}/{categoria?}")]
        public string Index()
        {
            return
                "Primeira Instancia" + Environment.NewLine +
                OperacaoService.Transient.OperacaoId + Environment.NewLine +
                OperacaoService.Scoped.OperacaoId + Environment.NewLine +
                OperacaoService.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Segunda Instancia" + Environment.NewLine +
                OperacaoService2.Transient.OperacaoId + Environment.NewLine +
                OperacaoService2.Scoped.OperacaoId + Environment.NewLine +
                OperacaoService2.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService2.SingletonInstance.OperacaoId + Environment.NewLine;
        }

        //[Route("")] 
        //[Route("pagina-inicial")]
        //[Route("pagina-inicial/{id}/{categoria?}")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
 