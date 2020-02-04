using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OracleSampleProject.Models;

// add namespaces
using dispayData.Models;
using getFormData.Models;

namespace OracleSampleProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ODPSelectClass sqldata = new ODPSelectClass();
            sqldata.getSQLLIST();

            ViewBag.sqldata = sqldata;
            return View();
        }

        public IActionResult Form()
        {
            return View(new ODPInsertClass());
        }

        [HttpPost]
        public IActionResult Form(ODPInsertClass model)
        {
            /* Make sure that inputted value isn't null or empty */
            if (String.IsNullOrEmpty(model.FirstName)){
                ViewBag.Message = "Error: Don't submit an empty value.";
                return View();
            } 
            else {
                ODPInsertClass getFormData = new ODPInsertClass();
                getFormData.insertINTOSQLLIST(model.FirstName);
                ViewBag.Message = "Success: Value will be inserted into database";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
