using A._2._1_DemoMvcAtributteRoutes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace A._2._1_DemoMvcAtributteRoutes.Controllers
{   [Route("")]// Caso não especifique a home na url cai aqui na HomeController
    [Route("gestao-clientes")] // Prefixo de URL fixo para esta Controller e força a rota da Action

    public class HomeController : Controller
    {   
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("")]// Caso não especifique o action na url cai aqui
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id}")] //Recebendo um parametro
        [Route("pagina-inicial/{id}/{categoria?}")]//Recebendo dois parametros, id obrigatorio e categoria opcional
        [Route("pagina-inicial/{id:int}/{categoria:guid}")] //Definindo ID como tipo int que deve ser passado
        public IActionResult Index(int id, Guid categoria)
        {
            return View();
        }
        [Route("privacidade")]
        [Route("politica-de-privacidade")]// ESCOLHE ESSA AUTOMATICAMENTE NA URL PORQUE É A ULTIMA ROTA ESPECIFICADA  
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}