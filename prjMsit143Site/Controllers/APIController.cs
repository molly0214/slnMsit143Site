using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjMsit143Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prjMsit143Site.Controllers
{
    public class APIController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _context;
        public APIController (IWebHostEnvironment host, DemoContext context)
        {
            _host = host;
            _context = context;
        }
        //http://localhost.../api/index
        public IActionResult Index(string keyword) //接收client傳過來的資料
        {
            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "Ajax";
            }
            //回應單純字串 "Hello Ajax!!"
            return Content($"{keyword}, 您好 !!", "text/plain", System.Text.Encoding.UTF8);
        }

        public IActionResult Sleep()
        {
            System.Threading.Thread.Sleep(5000);
            return Content("Hello Ajax Event", "text/plain");
        }

        public IActionResult Register(Member member, IFormFile File1)
        {
            string filePath = Path.Combine(_host.WebRootPath, "uploads", File1.FileName);
            //將檔案存到資料夾中
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                File1.CopyTo(fileStream);
            }
            //將檔案轉成二進位
            byte[] imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                File1.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileName = File1.FileName;
            member.FileData = imgByte;

            //todo 將收到會員資料寫進資料庫中
            _context.Members.Add(member);
            _context.SaveChanges();

            //檔案上傳要知道實際路徑
            //要透過程式動態的取得程式執行當下的實際路徑
            //取得wwwroot的實際路徑
            // string info = _host.WebRootPath; 
            //取得專案資料夾的實際路徑
            //string info = _host.ContentRootPath; 

            //string info = $"{File1.FileName} - {File1.ContentType} - {File1.Length}";
            return Content(filePath, "text/plain");
        }

        //根據城市名稱讀取鄉鎮區的資料
        public IActionResult City()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        //根據城市名稱讀取鄉鎮區的資料
        public IActionResult Site(string city)
        {
            var sites = _context.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(sites);
        }


        //根據鄉鎮區名稱讀取路的資料
        public IActionResult Road(string site)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == site).Select(a => a.Road).Distinct();
            return Json(roads);
        }

        public IActionResult CheckAccount(string name)
        {
            var exists= _context.Members.Any(m => m.Name == name);
            return Content(exists.ToString(), "text/plain");

        }


        }
    }
