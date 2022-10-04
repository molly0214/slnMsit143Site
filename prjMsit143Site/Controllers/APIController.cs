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
        private readonly DemoContext _context;
        public APIController(DemoContext context)  //相依性注入
        {
            _context = context;
        }
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
            _context.Members.Add(member);
            _context.SaveChanges();
            return Content(member.Name, "text/plain");
        }
        public IActionResult CheckAccount(string Name)
        {
            bool LogOut = _context.Members.Any(e => e.Name == Name);
            if (string.IsNullOrEmpty(Name))
                return Content("請輸入文字", "text/plain");
            else if (LogOut)
                return Content("帳號已存在", "text/plain");
            else
                return Content("", "text/plain");
        }

    }
}
