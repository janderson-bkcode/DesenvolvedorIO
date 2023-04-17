using Microsoft.AspNetCore.Mvc;
using A._4_DemoMvcViews.Models;

namespace A._4_DemoMvcViews.Controllers
{
    public class FilmesController : Controller


    {   [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Adicionar(Filme filme)
        {
            if (ModelState.IsValid)
            {
                //
            }
            return View(filme);
        }


    }
}
