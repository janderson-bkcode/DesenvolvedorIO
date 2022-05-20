using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class FilmeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        public IActionResult Adicionar()
        {
            Title = "Adicionar Filme";
            return View();
        }
    }
}
