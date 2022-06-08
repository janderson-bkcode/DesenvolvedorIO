using AspNetCoreIdentity.Extensions;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize] // Tem que estar logado para acessar 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]// Este pode acessar sem logar

        public IActionResult Index()
        {
            return View();
        }
 
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles="Admin,Gestor")] //Apenas admin acessa 
        public IActionResult Secret()
        {
            return View();
        } 
        
        [Authorize(Policy ="PodeExcluir")] //Claim   
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [ClaimsAuthorizeAtrribute("Home","Secret")] //Claim   
        public IActionResult ClaimCustom()
        {
            return View("Secret");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}