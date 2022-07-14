using ClosedXML.Excel;
using ExcelFormLuiza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using static ExcelFormLuiza.Data.DataContext;

namespace ExcelFormLuiza.Controllers
{
    public class ExcelFormLuizaController : Controller
    {
        private readonly ILogger<ExcelFormLuizaController> _logger;
        private readonly myDataContext _context;

        public ExcelFormLuizaController(ILogger<ExcelFormLuizaController> logger, myDataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<User> users = _context.users.ToList();
            return View(users);

        }

        public IActionResult ExportExcel()
        {
            var users = _context.users.ToList();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(Common.ToDataTable(users.ToList()));
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "customer.xlsx");
                }
            }
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> GetUsers(UserExcelFormManualRequest request)
        //{

        //    List<User> response = _GetUsersResponse.GetPosPixTransaction(request);


        //    return PartialView(response);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

 
}

