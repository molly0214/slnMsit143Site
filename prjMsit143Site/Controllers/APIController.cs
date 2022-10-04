using Microsoft.AspNetCore.Mvc;
using prjMsit143Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMsit143Site.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index(string keyword)//接收client傳過來的資料
        {
            //https://localhost:44306/API/index
            //回應單純字串 "HELLO AJAX!!"

            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "AJAX";
            }

            return Content($"{ keyword},AJAX!", "text/html",System.Text.Encoding.UTF8);
        }

        public IActionResult Sleep()
        {
            System.Threading.Thread.Sleep(5000);
            return Content("Hello AJAX Event", "text/plain");
        }

        public IActionResult Register(Member member)
        {

            //todo 把收到的會員資料寫進資料庫裡
            return Content(member.Name, "text/plain");

        }
    }
}
