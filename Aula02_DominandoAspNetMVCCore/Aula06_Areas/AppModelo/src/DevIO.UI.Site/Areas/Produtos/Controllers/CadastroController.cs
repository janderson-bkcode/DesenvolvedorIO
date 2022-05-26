using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Areas.Produtos.Controllers
{
    public class CadastroController : Controller
    {
        [Area("Produtos")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
