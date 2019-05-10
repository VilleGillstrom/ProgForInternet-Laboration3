using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnnonsSystem.Controllers;
using Microsoft.AspNetCore.Http;

namespace AnnonsSystem.Controllers
{

   
    public class HomeController : Controller
    {
        public IActionResult Index()
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

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            ViewBag.Message = "foo";
            return View();
        }

        [HttpPost] /* Create */
        public IActionResult MyButton(IFormCollection collection)
        {
            ViewBag.Message = "MyAction";
            return View("Index");
        }

        [HttpPost] /* Create */
        public IActionResult Prenumerant(IFormCollection collection)
        {
            ViewBag.Data = new List<string>() {"foo", "bar", "baz" };
            return View();
        }


    }
}
