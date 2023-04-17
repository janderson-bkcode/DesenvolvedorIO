using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentity.Areas.Anime.Controllers
{
    [Area("Anime")]
    public class AnimeController : Controller
    {
        [Route("index")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Anime()
        {
            return View();
        }
        [Authorize]
        public IActionResult Manga()
        {
            return View();
        }


    }
}
