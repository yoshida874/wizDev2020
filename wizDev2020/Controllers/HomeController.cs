using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wizDev2020.Models;
using System.Text.Json;
using wizDev2020.Data;
using System.Data.SqlClient;

namespace wizDev2020.Controllers
{
    public class HomeController : Controller
    {
        private readonly Wizdev2020Context _context;

        public HomeController(Wizdev2020Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            using (_context)
            {
                var historic_monument = from h in _context.HistricMonuments
                                       select new { name = h.monument_name,information = h.monument_information, lng = h.monument_longitude, lat = h.monument_latitude };

                ViewBag.json = JsonSerializer.Serialize(historic_monument);
            }

           

            return View();
        }

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
