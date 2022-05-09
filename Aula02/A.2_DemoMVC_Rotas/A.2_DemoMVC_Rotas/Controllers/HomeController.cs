using A._2_DemoMVC_Rotas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace A._2_DemoMVC_Rotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
            //Return View("Privacy") Outra forma de chamar a view caso o nome
            //do método seja diferente do arquivo
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}