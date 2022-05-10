using A2._3_DemoMVCResults.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace A2._3_DemoMVCResults.Controllers
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
        }

        public IActionResult Privacy()
        {
            //return Json("{nome:Eduardo}");
            var fileBytes = System.IO.File.ReadAllBytes(@"c:\arquivo.txt");
            var filename = "arquivos.txt";
            return File(fileBytes,System.Net.Mime.MediaTypeNames.Application.Octet,filename);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}