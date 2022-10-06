using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMsit143Site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace prjMsit143Site.Controllers
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
            return View();
        }

        public IActionResult First()
        {
            return View();
        }
        public IActionResult GetDemo()
        {
            return View();
        }
        public IActionResult AjaxEvent()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Address()
        {
            return View();
        }
        public IActionResult Promise()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult jQuery()
        {
            return View();
        }
        public IActionResult ShipperCors()
        {
            return View();
        }
        public IActionResult ShippShipperCorsEmptyerCors()
        {
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
