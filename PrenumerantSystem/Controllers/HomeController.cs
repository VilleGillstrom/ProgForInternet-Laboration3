using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrenumerantSystem.Controllers;
using PrenumerantSystem.Models;
using PrenumerantSystem.Services;

namespace PrenumerantSystem.Controllers
{
    public class HomeController : Controller
    {

        IPrenumerantRepository _prenumerantRepository;
        public HomeController(IPrenumerantRepository prenumerantRepository)
        {
            _prenumerantRepository = prenumerantRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

        /* Just for debugging */
        public IActionResult ListPrenumerants()
        {

            var prenumerants = _prenumerantRepository.GetPrenumerants();
            var results = new List<PrenumerantDto>();

            foreach (var p in prenumerants)
            {
                results.Add(new PrenumerantDto()
                {
                    PrenumerantNummer = p.PrenumerantNummer.ToString(),
                    Efternamn = p.Efternamn,
                    Fornamn = p.Fornamn,
                    Personnummer = p.Personnummer,
                    Postnummer = p.Postnummer,
                    Utdelningsadress = p.Utdelningsadress

                });
            }
            return View(results);
        }
    }
}
