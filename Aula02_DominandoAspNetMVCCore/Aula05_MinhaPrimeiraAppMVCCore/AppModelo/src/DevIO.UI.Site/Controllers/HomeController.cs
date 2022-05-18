using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ikvm.runtime;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DevIO.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        [Route("")] 
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id}/{categoria?}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
