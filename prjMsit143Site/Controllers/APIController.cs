using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMsit143Site.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index()
        {
            //https://localhost:44306/API/index
            //回應單純字串 "HELLO AJAX!!"

            return Content(" 안녕하십니까 HELLO AJAX!!", "text/html",System.Text.Encoding.UTF8);
        }
    }
}
