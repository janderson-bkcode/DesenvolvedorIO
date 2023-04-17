using A3_DemoMVCModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace A3_DemoMVCModels.Controllers
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
            var filme = new Filme()
            {
                Titulo = "Oi,",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 2000
            };

            //Redireciona para Action Privacy abaixo e passa o filme como parâmetro
            return RedirectToAction("Privacy", filme);
            //return View();
        }

        public IActionResult Privacy(Filme filme)
        {
            //Verifica se a validação da Model esta ok
            if (ModelState.IsValid)
            {

            }

            //Coletando e exibindo  erros da Model na tela 
            foreach (var error in ModelState.Values.SelectMany(m=> m.Errors)) 
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(filme); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}