using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Modulos.Produtos.Controllers
{
    public class TesteController : Controller
    {
        [Area("Produtos")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
