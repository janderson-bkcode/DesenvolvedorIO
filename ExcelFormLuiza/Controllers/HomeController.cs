
using ClosedXML.Excel;
using Domain.Models.Request;
using ExcelFormLuiza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static ExcelFormLuiza.Data.DataContext;

namespace ExcelFormLuiza.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly myDataContext _context;

        public HomeController(ILogger<HomeController> logger,myDataContext context)
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

    public static class Common
    {
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
