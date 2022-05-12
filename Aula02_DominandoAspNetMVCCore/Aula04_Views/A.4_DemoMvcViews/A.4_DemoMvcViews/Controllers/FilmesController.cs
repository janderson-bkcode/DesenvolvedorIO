using Microsoft.AspNetCore.Mvc;

namespace A._4_DemoMvcViews.Controllers
{
    public class FilmesController : Controller


    {   [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
    }
}
