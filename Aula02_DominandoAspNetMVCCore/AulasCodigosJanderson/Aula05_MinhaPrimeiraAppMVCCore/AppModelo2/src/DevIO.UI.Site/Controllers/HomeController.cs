using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
   

    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        public IActionResult Index()
        {
            Title = "Meu Aplicativo";
            return View();
        }
    }
}
